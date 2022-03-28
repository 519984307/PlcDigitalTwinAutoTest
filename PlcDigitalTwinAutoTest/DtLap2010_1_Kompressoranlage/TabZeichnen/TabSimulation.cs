﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLap2010_1_Kompressoranlage.ViewModel;

namespace DtLap2010_1_Kompressoranlage.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLap2010 vmLap2010, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, true);

        var buttonRand = new Thickness(2, 5, 2, 5);
        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        libWpf.RechteckFill(20, 11, 1, 9, Brushes.LightGray);

        libWpf.Text("S1", 19, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S2", 24, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P1", 19, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P2", 24, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ButtonContentRounded(22, 3, 2, 3, 20, 15, buttonRand, Brushes.Red, vmLap2010.BtnTaster, WpfObjects.S1);
        libWpf.ButtonContentRounded(27, 3, 2, 3, 20, 15, buttonRand, Brushes.Green, vmLap2010.BtnTaster, WpfObjects.S2);

        libWpf.KreisStrokeMarginSetFilling(22, 3, 6, 3, kreisRandFarbe, kreisRand, WpfObjects.P1);
        libWpf.KreisStrokeMarginSetFilling(27, 3, 6, 3, kreisRandFarbe, kreisRand, WpfObjects.P2);


        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////

        libWpf.RechteckFillStrokeRundung(2, 20, 1, 15, 25, 15, Brushes.LightBlue, Brushes.Black, 2, new Rect(0, 0, 210, 300));
        libWpf.RechteckFillStrokeMargin(4, 3, 11, 3, Brushes.LightBlue, Brushes.Black, 2, new Thickness(10, 0, 10, 0));
        libWpf.RechteckFillMargin(4, 3, 10, 2, Brushes.LightBlue, new Thickness(12, 0, 12, 0));

        libWpf.Polygon(0, 7, 15, 6, Brushes.LightBlue, Brushes.Black, 2, new[] { new double[] { 130, 20 }, new double[] { 200, 20 }, new double[] { 200, 150 }, new double[] { 20, 150 }, new double[] { 20, 90 }, new double[] { 130, 90 } });

        libWpf.KreisFillStrokeMargin(3, 5, 12, 5, Brushes.Blue, Brushes.Black, 2, new Thickness(10, 10, 10, 10));
        libWpf.Polygon(3, 5, 13, 5, Brushes.Blue, Brushes.Black, 2, new[] { new double[] { 70, 2 }, new double[] { 90, 30 }, new double[] { 50, 30 } });


        var kontakteRand = new Thickness(0, 5, 5, 5);

        libWpf.Text("B1", 9, 2, 5, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.BildSichtbarkeitAus("InitiatorenSchliesser.jpg", 11, 2, 5, 2, kontakteRand, WpfObjects.B1);
        libWpf.BildSichtbarkeitEin("InitiatorenBetaetigt.jpg", 11, 2, 5, 2, kontakteRand, WpfObjects.B1);



        libWpf.RechteckSetFill(10, 4, 15, 1, Brushes.Black, new Thickness(0, 0, 0, 0), WpfObjects.Q1);
        libWpf.RechteckSetFill(10, 2, 16, 1, Brushes.Black, new Thickness(0, 0, 0, 0), WpfObjects.Q2);
        libWpf.RechteckSetFill(12, 2, 16, 1, Brushes.Black, new Thickness(0, 0, 0, 0), WpfObjects.Q3);
        libWpf.Text("Q1 (Netz)", 10, 4, 15, 1, HorizontalAlignment.Center, VerticalAlignment.Center, 15, Brushes.Black);
        libWpf.Text("Q2 ( Y )", 10, 2, 16, 1, HorizontalAlignment.Center, VerticalAlignment.Center, 15, Brushes.Black);
        libWpf.Text("Q3 ( △ )", 12, 2, 16, 1, HorizontalAlignment.Center, VerticalAlignment.Center, 15, Brushes.Black);


        libWpf.ButtonBackgroundContentRounded(10, 4, 18, 2, 14, 5, new Thickness(0,0,0,0), vmLap2010.BtnSchalter, WpfObjects.F1);

        libWpf.TextSetContendSetVisibility(10, 4, 18, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, WpfObjects.Kurzschluss);
        libWpf.KreisStrokeMarginSetFilling(15, 4, 15, 4, Brushes.Red, new Thickness(0, 0, 0, 0), WpfObjects.Kurzschluss);


        libWpf.PointerGauge(20, 10, 12, 10, "Druck", 0, 10, 165, 188, "AktuellerDruck");

        // libWpf.PlcError();
    }
}