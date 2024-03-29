﻿using DtLeitungszuordnungsTester.ViewModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtLeitungszuordnungsTester.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLeitungszuordnungsTester vmLeitungszuordnungsTester, TabItem tabItem, string hintergrund)
    {
        _ = vmLeitungszuordnungsTester;
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 40, false, false, false);

        libWpf.PlcError();
    }
}