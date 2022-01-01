﻿using System.Text;
using System.Threading;
using LibPlc;
using SoftCircuits.Silk;

namespace LibSilkAutoTester.Silk;

public partial class Silk
{
    private static int _anzahlBitEingaenge = 16;
    private static int _anzahlBitAusgaenge = 16;
    private static void IncrementDataGridId()
    {
        /*
        AutoTesterWindow.DataGridId++;

        if (Datenstruktur.BetriebsartTestablauf == BetriebsartTestablauf.Automatik) return;

        while (!Datenstruktur.NaechstenSchrittGehen)
        {
            Thread.Sleep(10);
        }

        Datenstruktur.NaechstenSchrittGehen = false;
        */
    }
    private static void UpdateAnzeige(FunctionEventArgs e)
    {
        var silkTestergebnis = e.Parameters[0].ToString();
        var silkKommentar = e.Parameters[1].ToString();

        // ReSharper disable once ConvertSwitchStatementToSwitchExpression
        var ergebnis = silkTestergebnis switch
        {
            "Kommentar" => TestAutomat.TestAnzeige.Kommentar,
            "Aktiv" => TestAutomat.TestAnzeige.Aktiv,
            "Init" => TestAutomat.TestAnzeige.Init,
            "Erfolgreich" => TestAutomat.TestAnzeige.Erfolgreich,
            "Timeout" => TestAutomat.TestAnzeige.Timeout,
            "Fehler" => TestAutomat.TestAnzeige.Fehler,
            "Test abgeschlossen"=> TestAutomat.TestAnzeige.Kommentar,
            _ => TestAutomat.TestAnzeige.UnbekanntesErgebnis
        };

        DataGridAnzeigeUpdaten(ergebnis, 0, silkKommentar);
    }
    private static void DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige testAnzeige, uint digOutSoll, string silkKommentar)
    {
        var digitalInput = GetDigtalInputWord();
        var digitalOutput = GetDigitalOutputWord();

        var dInput = new Uint(digitalInput.ToString());
        var dOutputIst = new Uint(digitalOutput.ToString());
        var dOutputSoll = new Uint(digOutSoll.ToString());
        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        switch (testAnzeige)
        {
            case TestAutomat.TestAnzeige.Kommentar:
            case TestAutomat.TestAnzeige.Version:
                /*
                AutoTesterWindow.UpdateDataGrid(new TestAusgabe(
                    AutoTesterWindow.DataGridId,
                    " ",
                    testErgebnis,
                    silkKommentar,   // DigInput 
                    " ",             // DigOutput Soll
                    " ",             // DigOutput Ist
                    " "));
                */
                break;
            default:
                /*
                AutoTesterWindow.UpdateDataGrid(new TestAusgabe(
                    AutoTesterWindow.DataGridId,
                    $"{SilkStopwatch.ElapsedMilliseconds}ms",
                    testErgebnis,
                    dInput.GetHexBit(_anzahlBitEingaenge) + "  " + dInput.GetBinBit(_anzahlBitEingaenge),            // DigInput 
                    dOutputSoll.GetHexBit(_anzahlBitAusgaenge) + "  " + dOutputSoll.GetBinBit(_anzahlBitAusgaenge),  // DigOutput Soll                                                                                   // DigOutput Soll
                    dOutputIst.GetHexBit(_anzahlBitAusgaenge) + "  " + dOutputIst.GetBinBit(_anzahlBitAusgaenge),    // DigOutput Ist
                    silkKommentar));
                */
                break;
        }
    }
    private static void KommentarAnzeigen(FunctionEventArgs e)
    {
        var kommentar = e.Parameters[0].ToString();
        // AutoTesterWindow.DataGridId++;
        // DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Kommentar, 0, kommentar);
    }
    private static void VersionAnzeigen()
    {
      //  var textLaenge = Datenstruktur.VersionInputSps[1];
        var enc = new ASCIIEncoding();
        //  var version = enc.GetString(Datenstruktur.VersionInputSps, 2, textLaenge);

        //   DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Version, 0, version);
        //  AutoTesterWindow.DataGridId++;
    }
}