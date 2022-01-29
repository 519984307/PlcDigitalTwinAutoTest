﻿using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using BasePlcDtAt.BaseViewModel;
using LibAutoTest;
using LibConfigPlc;
using LibDatenstruktur;
using LibDisplayPlc;
using LibPlcTestautomat;

namespace BasePlcDtAt;

public partial class BaseWindow
{
    public Datenstruktur Datenstruktur { get; set; }
    public ConfigPlc ConfigPlc { get; set; }
    public DisplayPlc DisplayPlc { get; set; }
    public AutoTest AutoTest { get; set; }
    public TestAutomat TestAutomat { get; set; }

    private readonly VmBase _vmBase;
    private readonly CancellationTokenSource _cancellationTokenSource;
    private const string PfadConfigTests = "ConfigTests";
    private const string PfadConfigPlc = "ConfigPlc";

    public BaseWindow(VmBase vmBase, Datenstruktur datenstruktur, int startUpTabIndex, CancellationTokenSource cancellationTokenSource)
    {
        _vmBase = vmBase;
        Datenstruktur = datenstruktur;
        _cancellationTokenSource = cancellationTokenSource;

        InitializeComponent();
        DataContext = _vmBase;

        ConfigPlc = new ConfigPlc(PfadConfigPlc);

        _vmBase.BeschreibungZeichnen(TabBeschreibung);
        _vmBase.LaborPlatteZeichnen(TabLaborPlatte);
        _vmBase.SimulationZeichnen(TabSimulation);

        TestAutomat = new TestAutomat(Datenstruktur);

        AutoTest = new AutoTest(Datenstruktur, ConfigPlc, TabAutoTest, TestAutomat, PfadConfigTests);
        AutoTest.SetCallback(ConfigPlc.SetPath);
        _vmBase.SetAutoTestRef(AutoTest);

        BaseTabControl.SelectedIndex = startUpTabIndex;
        DisplayPlc = new DisplayPlc(Datenstruktur, ConfigPlc, _cancellationTokenSource);
    }
    private void BetriebsartProjektChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is not TabControl tc) return;

        switch (tc.SelectedIndex)
        {
            case (int)VmBase.WpfBase.TabBeschreibung:
                ConfigPlc.SetPathRelativ(PfadConfigPlc);
                Datenstruktur.BetriebsartProjekt = BetriebsartProjekt.BeschreibungAnzeigen;
                break;
            case (int)VmBase.WpfBase.TabLaborplatte:
                ConfigPlc.SetPathRelativ(PfadConfigPlc);
                Datenstruktur.BetriebsartProjekt = BetriebsartProjekt.LaborPlatte;
                break;
            case (int)VmBase.WpfBase.TabSimulation:
                ConfigPlc.SetPathRelativ(PfadConfigPlc);
                Datenstruktur.BetriebsartProjekt = BetriebsartProjekt.Simulation;
                break;
            case (int)VmBase.WpfBase.TabAutoTest:
                AutoTest.ResetSelectedProject();
                Datenstruktur.BetriebsartProjekt = BetriebsartProjekt.AutomatischerSoftwareTest;
                break;
            default:
                Datenstruktur.BetriebsartProjekt = Datenstruktur.BetriebsartProjekt;
                break;
        }
    }
    private void PlcButtonClick(object sender, RoutedEventArgs e)
    {
        if (DisplayPlc.FensterAktiv) DisplayPlc.Schliessen();
        else DisplayPlc.Oeffnen();
    }
    private void PlotterButtonClick(object sender, RoutedEventArgs e) => _vmBase.PlotterButtonClick(sender, e);
    private void BaseWindow_OnClosing(object sender, CancelEventArgs e)
    {
        _cancellationTokenSource.Cancel();
        Application.Current.Shutdown();
    }
}