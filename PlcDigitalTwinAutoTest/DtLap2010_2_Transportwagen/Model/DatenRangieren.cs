﻿using LibDatenstruktur;

namespace DtLap2010_2_Transportwagen.Model;

public class DatenRangieren

{
    private readonly ModelLap2010 _modelLap2010;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelLap2010 modelLap2010, Datenstruktur datenstruktur)
    {
        _modelLap2010 = modelLap2010;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        if (_datenstruktur.SimulationAktiv())
        {
            _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _modelLap2010.B1, _modelLap2010.B2, _modelLap2010.F1, _modelLap2010.S1, _modelLap2010.S2, _modelLap2010.S3);
        }
        else
        {
            (_modelLap2010.B1, _modelLap2010.B2, _modelLap2010.F1, _modelLap2010.S1, _modelLap2010.S2, _modelLap2010.S3, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Di, 0);
        }

        (_modelLap2010.P1, _modelLap2010.Q1, _modelLap2010.Q2, _, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}