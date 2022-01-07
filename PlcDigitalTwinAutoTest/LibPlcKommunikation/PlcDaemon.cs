﻿using System.Net.NetworkInformation;
using LibDatenstruktur;
using Newtonsoft.Json;

namespace LibPlcKommunikation;

public class PlcDaemon
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public PlcKeine PlcKeine { get; set; }
    public PlcBeckhoff PlcBeckhoff { get; set; }
    public PlcSiemens PlcSiemens { get; set; }

    public byte[] Pc2Plc = new byte[1024];
    public byte[] Plc2Pc = new byte[1024];

    public short AnzBytePc2Plc = 222;
    public short AnzBytePlc2Pc = 222;

    private readonly Datenstruktur _datenstruktur;
    private readonly IpAdressenSiemens _ipAdressenSiemens;
    private readonly IpAdressenBeckhoff _ipAdressenBeckhoff;
    private PlcDaemonStatus _plcDaemonStatus;




    private enum PlcDaemonStatus
    {
        SpsPingen = 0,
        SpsBeckhoff = 1,
        SpsSiemens = 2
    }


    public PlcDaemon(Datenstruktur datenstruktur)
    {
        Log.Debug("gestartet!");

        _datenstruktur = datenstruktur;

        try
        {
            _ipAdressenSiemens = JsonConvert.DeserializeObject<IpAdressenSiemens>(File.ReadAllText("IpAdressenSiemens.json"));
        }
        catch (Exception ex)
        {
            Log.Debug("Datei nicht gefunden: IpAdressenSiemens.json" + ex);
        }

        try
        {
            _ipAdressenBeckhoff = JsonConvert.DeserializeObject<IpAdressenBeckhoff>(File.ReadAllText("IpAdressenBeckhoff.json"));
        }
        catch (Exception ex)
        {
            Log.Debug("Datei nicht gefunden: IpAdressenBeckhoff.json" + ex);
        }

        PlcKeine = new PlcKeine();
        PlcBeckhoff = new PlcBeckhoff(_ipAdressenBeckhoff, Pc2Plc, Plc2Pc);
        PlcSiemens = new PlcSiemens(_ipAdressenSiemens, Pc2Plc, Plc2Pc);

        Task.Run(PlcDaemonTask);
    }
    private void PlcDaemonTask()
    {
        var pingBeckhoff = new Ping();
        var pingSiemens = new Ping();

        while (true)
        {
            switch (_plcDaemonStatus)
            {
                case PlcDaemonStatus.SpsPingen:
                    _ = PlcKeine.PlcTask();

                    try
                    {
                        var replyBeckhoff = pingBeckhoff.Send(_ipAdressenBeckhoff.IpAdresse);
                        var replySiemens = pingSiemens.Send(_ipAdressenSiemens.Adress);

                        if (replyBeckhoff is { Status: IPStatus.Success }) _plcDaemonStatus = PlcDaemonStatus.SpsBeckhoff;
                        if (replySiemens is { Status: IPStatus.Success }) _plcDaemonStatus = PlcDaemonStatus.SpsSiemens;
                    }
                    catch (Exception ex)
                    {
                        Log.Debug("Problem beim pingen:" + ex);
                    }
                    break;

                case PlcDaemonStatus.SpsBeckhoff:
                    if (PlcBeckhoff.PlcTask()) _plcDaemonStatus = PlcDaemonStatus.SpsPingen;
                    break;

                case PlcDaemonStatus.SpsSiemens:
                    if (PlcSiemens.PlcTask()) _plcDaemonStatus = PlcDaemonStatus.SpsPingen;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            DatenRangieren();

            Thread.Sleep(10);
        }
        // ReSharper disable once FunctionNeverReturns
    }

    private void DatenRangieren()
    {
        //https://support.industry.siemens.com/cs/ww/de/view/109747136
        // S7-1200: 240 Byte
        // 222 Byte maximal

        const int anzDi = 32;
        const int anzAi = 64;
        const int anzBefehle = 32;

        const int anzDa = 32;
        const int anzAa = 64;
        const int laengeVersionsbez = 128;

        if (anzDi + anzAi + anzBefehle > AnzBytePc2Plc) throw new ArgumentOutOfRangeException();
        if (anzDa + anzAa + laengeVersionsbez > AnzBytePlc2Pc) throw new ArgumentOutOfRangeException();


        Buffer.BlockCopy(_datenstruktur.Di, 0, Pc2Plc, 0, anzDi);
        Buffer.BlockCopy(_datenstruktur.Ai, 0, Pc2Plc, anzDi, anzAi);
        Buffer.BlockCopy(_datenstruktur.BefehlePlc, 0, Pc2Plc, anzDi + anzAi, anzBefehle);

        Buffer.BlockCopy(Plc2Pc, 0, _datenstruktur.Da, 0, anzDa);
        Buffer.BlockCopy(Plc2Pc, anzDa, _datenstruktur.Aa, 0, anzAa);
        Buffer.BlockCopy(Plc2Pc, anzDa + anzAa, _datenstruktur.VersionsStringPlc, 0, laengeVersionsbez);
    }
}