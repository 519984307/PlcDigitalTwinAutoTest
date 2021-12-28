﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtBlinker.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabLaborPlatteZeichnen(Grid grid, bool gridSichtbar, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(grid);

        libWpf.GridZeichnen(50, 30, 30, 30, gridSichtbar);

        libWpf.Text("Laborplatte", 2, 20, 25, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 30, Brushes.Black);
        
        libWpf.PlcError(libWpf);
    }
}