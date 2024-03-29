﻿using Sharp7;

namespace LibPlcKommunikation;

public enum SiemensDatenbausteine
{
    PcToPlc = 1,
    PlcToPc = 2
}

public class PlcSiemens : IPlc
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public short AnzBytePcToPlc = 222;
    public short AnzBytePlcToPc = 222;

    private readonly IpAdressenSiemens _ipAdressenSiemens;
    private readonly byte[] _pcToPlc;
    private readonly byte[] _plcToPc;
    private readonly S7Client _s7Client;
    private SiemensStatus _siemensStatus;

    private enum SiemensStatus
    {
        Verbinden = 0,
        Kommunizieren = 1
    }

    public PlcSiemens(IpAdressenSiemens ipAdressenSiemens, byte[] pcToPlc, byte[] plcToPc)
    {
        Log.Debug("gestartet!");

        _ipAdressenSiemens = ipAdressenSiemens;
        _pcToPlc = pcToPlc;
        _plcToPc = plcToPc;
        _s7Client = new S7Client();
    }
    public PlcState State => new()
    {
        PlcBezeichnung = "S7-1200",
        PlcError = false,
        PlcErrorMessage = "-"
    };
    public void PlcTask()
    {
        var error = false;

        switch (_siemensStatus)
        {
            case SiemensStatus.Verbinden:
                var connect = _s7Client?.ConnectTo(_ipAdressenSiemens.Adress, 0, 1);

                if (connect == 0)
                {
                    State.PlcErrorMessage = "-";
                    _siemensStatus = SiemensStatus.Kommunizieren;
                }
                else
                {
                    FehlerAktiv(connect);
                }
                break;

            case SiemensStatus.Kommunizieren:
                error |= FehlerAktiv(_s7Client.DBWrite((int)SiemensDatenbausteine.PcToPlc, 0, AnzBytePcToPlc, _pcToPlc));
                error |= FehlerAktiv(_s7Client.DBRead((int)SiemensDatenbausteine.PlcToPc, 0, AnzBytePlcToPc, _plcToPc));
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        if (error) _siemensStatus = SiemensStatus.Verbinden;
        State.PlcError = error;
    }
    private bool FehlerAktiv(int? error)
    {
        if (error == 0) return false;

        var errorNr = error.GetValueOrDefault();
        var errorText = _s7Client?.ErrorText(errorNr);
        State.PlcErrorMessage = "#" + errorNr + " --> " + errorText;
        return true;
    }
}