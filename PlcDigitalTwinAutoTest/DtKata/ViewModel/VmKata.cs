﻿using Contracts;
using DtKata.Model;
using LibDatenstruktur;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtKata.ViewModel;
public enum WpfObjects
{
    // ReSharper disable once UnusedMember.Global
    ReserveFuerBasisViewModel = 20, // enum WpfBase

    P1 = 21,
    P2 = 22,
    P3 = 23,
    P4 = 24,
    P5 = 25,
    P6 = 26,
    P7 = 27,
    P8 = 28,

    S1 = 31,
    S2 = 32,
    S3 = 33,
    S4 = 34,
    S5 = 35,
    S6 = 36,
    S7 = 37,
    S8 = 38
}
public partial class VmKata : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelKata _modelKata;
    private readonly Datenstruktur _datenstruktur;

    public VmKata(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _modelKata = model as ModelKata;
        _datenstruktur = datenstruktur;

        VisibilityTabBeschreibung = Visibility.Collapsed;
        VisibilityTabLaborplatte = Visibility.Collapsed;
        VisibilityTabSimulation = Visibility.Visible;
        VisibilityTabSoftwareTest = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnLinkHomepageAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnAlwarmVerwaltungAnzeigen] = Visibility.Visible;

        Text[(int)WpfObjects.S1] = "S1";
        Text[(int)WpfObjects.S2] = "S2";
        Text[(int)WpfObjects.S3] = "S3";
        Text[(int)WpfObjects.S4] = "S4";
    }
    protected override void ViewModelAufrufThread()
    {
        if (_modelKata == null) return;
        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        (VisibilityEinS1, VisibilityAusS1) = SetVisibility(_modelKata.S1);
        (VisibilityEinS2, VisibilityAusS2) = SetVisibility(_modelKata.S2);
        (VisibilityEinS3, VisibilityAusS3) = SetVisibility(_modelKata.S3);
        (VisibilityEinS4, VisibilityAusS4) = SetVisibility(_modelKata.S4);
        (VisibilityEinS5, VisibilityAusS5) = SetVisibility(_modelKata.S5);
        (VisibilityEinS6, VisibilityAusS6) = SetVisibility(_modelKata.S6);
        (VisibilityEinS7, VisibilityAusS7) = SetVisibility(_modelKata.S7);
        (VisibilityEinS8, VisibilityAusS8) = SetVisibility(_modelKata.S8);
        
        FarbeUmschalten(_modelKata.P1, (int)WpfObjects.P1, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_modelKata.P2, (int)WpfObjects.P2, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_modelKata.P3, (int)WpfObjects.P3, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_modelKata.P4, (int)WpfObjects.P4, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_modelKata.P5, (int)WpfObjects.P5, Brushes.Yellow, Brushes.White);
        FarbeUmschalten(_modelKata.P6, (int)WpfObjects.P6, Brushes.Yellow, Brushes.White);
        FarbeUmschalten(_modelKata.P7, (int)WpfObjects.P7, Brushes.Red, Brushes.White);
        FarbeUmschalten(_modelKata.P8, (int)WpfObjects.P8, Brushes.Red, Brushes.White);
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        switch (tasterId)
        {
            case WpfObjects.S1: _modelKata.S1 = gedrueckt; break;
            case WpfObjects.S2: _modelKata.S2 = gedrueckt; break;
            case WpfObjects.S3: _modelKata.S3 = !gedrueckt; break;
            case WpfObjects.S4: _modelKata.S4 = !gedrueckt; break;
            default: throw new ArgumentOutOfRangeException(nameof(tasterId));
        }
    }
    protected override void ViewModelAufrufSchalter(Enum schalterId)
    {
        switch (schalterId)
        {
            case WpfObjects.S5: _modelKata.S5 = !_modelKata.S5; break;
            case WpfObjects.S6: _modelKata.S6 = !_modelKata.S6; break;
            case WpfObjects.S7: _modelKata.S7 = !_modelKata.S7; break;
            case WpfObjects.S8: _modelKata.S8 = !_modelKata.S8; break;
            default: throw new ArgumentOutOfRangeException(nameof(schalterId));
        }
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}