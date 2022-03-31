﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLap2018_2_Abfuellanlage.ViewModel;

namespace DtLap2018_2_Abfuellanlage.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLap2018 vmLap2018, TabItem tabItem, string hintergrund)
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

        libWpf.RechteckFill(25, 11, 1, 19, Brushes.LightGray);

        libWpf.Text("S1", 24, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S2", 29, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S3", 24, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S4", 29, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("F1", 24, 3, 10, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("P1", 24, 3, 16, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P2", 29, 3, 16, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);


        libWpf.ButtonContentRounded(27, 3, 2, 3, 20, 15, buttonRand, Brushes.Red, vmLap2018.BtnTaster, WpfObjects.S1);
        libWpf.ButtonContentRounded(32, 3, 2, 3, 20, 15, buttonRand, Brushes.Green, vmLap2018.BtnTaster, WpfObjects.S2);
        libWpf.ButtonContentRounded(27, 3, 6, 3, 16, 15, buttonRand, Brushes.LawnGreen, vmLap2018.BtnTaster, WpfObjects.S3);
        libWpf.ButtonContentRounded(32, 3, 6, 3, 16, 15, buttonRand, Brushes.MediumPurple, vmLap2018.BtnTaster, WpfObjects.S4);

        libWpf.ButtonContentRounded(27, 3, 10, 3, 14, 15, buttonRand, Brushes.Red, vmLap2018.BtnSchalter, WpfObjects.F1);


        libWpf.KreisStrokeMarginSetFilling(27, 3, 16, 3, kreisRandFarbe, kreisRand, WpfObjects.P1);
        libWpf.KreisStrokeMarginSetFilling(32, 3, 16, 3, kreisRandFarbe, kreisRand, WpfObjects.P2);

        libWpf.Text("Betrieb", 27, 3, 16, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("Störung", 32, 3, 16, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);



        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////

        libWpf.ButtonContentRounded(1, 3, 1, 3, 20, 15, buttonRand, Brushes.LightSkyBlue, vmLap2018.BtnTaster, WpfObjects.AllesReset);
        libWpf.ButtonContentRounded(19, 3, 1, 3, 16, 15, buttonRand, Brushes.LightSkyBlue, vmLap2018.BtnTaster, WpfObjects.TankNachfuellen);

        libWpf.RechteckFillMargin(4, 1, 1, 16, Brushes.Gray, new Thickness(10, 0, 6, 0));
        libWpf.RechteckFillMargin(5, 1, 1, 16, Brushes.Gray, new Thickness(17, 0, 0, 0));

        libWpf.BildSetVisibilityEinAus("VentilElektrischEin.jpg", "VentilElektrischAus.jpg", 7, 2, 15, 2, new Thickness(0, 0, 0, 0), WpfObjects.K2);
        libWpf.Text("K2", 6, 2, 15, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.RechteckFill(10, 8, 1, 10, Brushes.LightBlue);
        libWpf.RechteckFillStrokeSetMargin(10, 8, 1, 10, Brushes.Blue, Brushes.Blue, 0, WpfObjects.Pegel);

        libWpf.Text("K1", 11, 2, 13, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.BildSetVisibilityEinAus("VentilElektrischEin.jpg", "VentilElektrischAus.jpg", 12, 3, 13, 2, new Thickness(0, 0, 8, 0), WpfObjects.K1);
        libWpf.RechteckMarginSetFill(13, 2, 11, 2, new Thickness(25, 0, 25, 0), WpfObjects.Zuleitung);
        libWpf.RechteckMarginSetFill(13, 2, 15, 5, new Thickness(25, 0, 25, 0), WpfObjects.Ableitung);

        libWpf.RechteckFillMargin(4, 14, 20, 1, Brushes.Gray, new Thickness(15, 0, 15, 20));
        libWpf.RechteckFillMargin(4, 14, 22, 1, Brushes.Gray, new Thickness(15, 20, 15, 0));
        libWpf.KreisFillStrokeMargin(3, 3, 20, 3, Brushes.Gray, Brushes.Gray, 0, new Thickness(0, 0, 0, 0));
        libWpf.KreisFillStrokeMargin(16, 3, 20, 3, Brushes.Gray, Brushes.Gray, 0, new Thickness(0, 0, 0, 0));
        libWpf.KreisStrokeMarginSetFilling(3, 3, 20, 3, Brushes.Gray, new Thickness(5, 5, 5, 5), WpfObjects.Q1);
        libWpf.Text("Q1", 3, 3, 20, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("B1", 11, 2, 24, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.BildSetVisibilityEinAus("InitiatorenSchliesser.jpg", "InitiatorenBetaetigt.jpg", 13, 2, 24, 2, new Thickness(0, 0, 0, 0), WpfObjects.B1);


        libWpf.BildSetMarginVisibilityEin("Franziskaner.jpg", 1, 20, 1, 20, WpfObjects.Flasche1);
        libWpf.BildSetMarginVisibilityEin("Kellerbier.jpg", 1, 20, 1, 20, WpfObjects.Flasche2);
        libWpf.BildSetMarginVisibilityEin("OberLänder.jpg", 1, 20, 1, 20, WpfObjects.Flasche3);
        libWpf.BildSetMarginVisibilityEin("Franziskaner.jpg", 1, 20, 1, 20, WpfObjects.Flasche4);
        libWpf.BildSetMarginVisibilityEin("Kellerbier.jpg", 1, 20, 1, 20, WpfObjects.Flasche5);
        libWpf.BildSetMarginVisibilityEin("OberLänder.jpg", 1, 20, 1, 20, WpfObjects.Flasche6);

        libWpf.BildSetVisibilityEin("Fohrenburger0.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Fohrenburger0);
        libWpf.BildSetVisibilityEin("Fohrenburger1.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Fohrenburger1);
        libWpf.BildSetVisibilityEin("Fohrenburger2.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Fohrenburger2);
        libWpf.BildSetVisibilityEin("Fohrenburger3.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Fohrenburger3);
        libWpf.BildSetVisibilityEin("Fohrenburger4.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Fohrenburger4);
        libWpf.BildSetVisibilityEin("Fohrenburger5.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Fohrenburger5);
        libWpf.BildSetVisibilityEin("Fohrenburger6.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Fohrenburger6);

        libWpf.BildSetVisibilityEin("Mohren0.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Mohren0);
        libWpf.BildSetVisibilityEin("Mohren1.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Mohren1);
        libWpf.BildSetVisibilityEin("Mohren2.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Mohren2);
        libWpf.BildSetVisibilityEin("Mohren3.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Mohren3);
        libWpf.BildSetVisibilityEin("Mohren4.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Mohren4);
        libWpf.BildSetVisibilityEin("Mohren5.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Mohren5);
        libWpf.BildSetVisibilityEin("Mohren6.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Mohren6);


        // libWpf.PlcError();
    }
}