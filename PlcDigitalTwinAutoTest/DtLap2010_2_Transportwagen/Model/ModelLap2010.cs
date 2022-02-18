﻿using LibDatenstruktur;

namespace DtLap2010_2_Transportwagen.Model;

public class ModelLap2010 : BasePlcDtAt.BaseModel.BaseModel
{
    public bool Q1 { get; set; }    // Motor LL
    public bool Q2 { get; set; }    // Motor RL
    public bool P1 { get; set; }    // Störung
    public bool S1 { get; set; }    // Taster "Start"
    public bool S2 { get; set; }    // NotHalt
    public bool S3 { get; set; }    // Taster Reset
    public bool F1 { get; set; }    // Thermorelais
    public bool B1 { get; set; }    // Endschalter Links
    public bool B2 { get; set; }    // Endschalter Rechts
    public double Position { get; set; }
    public double AbstandRadRechts { get; set; }
    public bool Fuellen { get; internal set; }

    private const double Geschwindigkeit = 1;
    private const double RandLinks = 30;
    private const double RandRechts = 430;
    private const double MaximaleFuellzeit = 500; // Zykluszeit ist 10ms --> 5 oder7"
    private double _laufzeitFuellen;

    private readonly DatenRangieren _datenRangieren;

    public ModelLap2010(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource)
    {
        _datenRangieren = new DatenRangieren(this, datenstruktur);

        Position = 30;
        AbstandRadRechts = 100;

        F1 = true;
        S2 = true;
    }
    protected override void ModelThread()
    {
        if (B1) _laufzeitFuellen = 0;
        if (B2 && _laufzeitFuellen <= MaximaleFuellzeit) _laufzeitFuellen++;
        Fuellen = _laufzeitFuellen is > 1 and < MaximaleFuellzeit;

        if (Q1) Position -= Geschwindigkeit;
        if (Q2) Position += Geschwindigkeit;

        if (Position < RandLinks) Position = RandLinks;
        if (Position > RandRechts) Position = RandRechts;

        B1 = Position < RandLinks + 2;
        B2 = Position > RandRechts - 2;

        _datenRangieren.Rangieren();
    }
}