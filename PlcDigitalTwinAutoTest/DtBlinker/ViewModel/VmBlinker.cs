﻿using DtBlinker.Model;
using LibDatenstruktur;
using ScottPlot;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtBlinker.ViewModel;

public partial class VmBlinker : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelBlinker _modelBlinker;
    private readonly Datenstruktur _datenstruktur;
    private WpfPlot _scottPlot;
    private readonly double[] _zeitachse;
    private short _nextDataIndex = 1;
    private readonly double[] _wertLeuchtMelder;

    public VmBlinker(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _datenstruktur = datenstruktur;
        _wertLeuchtMelder = new double[5_000];
        _zeitachse = DataGen.Consecutive(5_000);

        VisibilityTabBeschreibung = Visibility.Collapsed;
        VisibilityTabLaborplatte = Visibility.Collapsed;
        VisibilityTabSimulation = Visibility.Visible;
        VisibilityTabSoftwareTest = Visibility.Visible;

        VisibilityBtnPlcAnzeigen = Visibility.Visible;
        VisibilityBtnPlottAnzeigen = Visibility.Visible;
        VisibilityBtnLinkHomepageAnzeigen = Visibility.Visible;
        VisibilityBtnAlarmVerwaltungAnzeigen = Visibility.Visible;

        _modelBlinker = model as ModelBlinker;
    }

    protected override void ViewModelAufrufThread()
    {
        if (_modelBlinker == null) return;

        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        BrushP1 = SetBrush(_modelBlinker.P1, Brushes.LawnGreen, Brushes.White);

        ScottPlotAktualisieren();
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem)
    {
        _scottPlot = TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");

        _scottPlot.Plot.YLabel("Leuchtmelder");
        _scottPlot.Plot.XLabel("Zeit [ms]");

        _scottPlot.Plot.AddScatter(_zeitachse, _wertLeuchtMelder, label: "LED");
    }
    private void ScottPlotAktualisieren()
    {
        if (_nextDataIndex >= 4_990) _nextDataIndex = 0;

        for (var i = 0; i < 10; i++)
        {
            _wertLeuchtMelder[_nextDataIndex + i] = _modelBlinker.P1 ? 1 : 0;
        }

        _nextDataIndex += 10;

        if (_scottPlot != null)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                _scottPlot.Plot.AxisAuto(0);
                _scottPlot.Render();
            });
        }
    }
}