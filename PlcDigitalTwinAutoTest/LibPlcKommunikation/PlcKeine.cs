﻿using LibDatenstruktur;

namespace LibPlcKommunikation;

public class PlcKeine : IPlc
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public PlcKeine(Datenstruktur datenstruktur)
    {
        Log.Debug("gestartet!");
        datenstruktur.VersionsStringPlc = "Keine SW vorhanden!";
    }
    public PlcState State => new()
    {
        PlcBezeichnung = "Keine SPS erkannt",
        PlcError = false,
        PlcErrorMessage = "Keine Fehlermeldung"
    };
#pragma warning disable CA1822 // Mark members as static
    public void PlcTask() { }
#pragma warning restore CA1822 // Mark members as static
}