﻿using DtKata.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtKata.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLap2018 vmKata, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, false);

        var buttonRand = new Thickness(2, 5, 2, 5);

        libWpf.ButtonRounded(1, 3, 1, 2, 20, 15, buttonRand, Brushes.LawnGreen, vmKata.BtnTaster, WpfObjects.S1);
        libWpf.ButtonRounded(1, 3, 3, 2, 20, 15, buttonRand, Brushes.LawnGreen, vmKata.BtnTaster, WpfObjects.S2);
        libWpf.ButtonRounded(1, 3, 5, 2, 20, 15, buttonRand, Brushes.Red, vmKata.BtnTaster, WpfObjects.S3);
        libWpf.ButtonRounded(1, 3, 7, 2, 20, 15, buttonRand, Brushes.Red, vmKata.BtnTaster, WpfObjects.S4);

        libWpf.ButtonZweiBilder(1, 3, 10, 2, 10, "SchiebeSchalterOn.jpg", "SchiebeSchalterOff.jpg", buttonRand, vmKata.BtnSchalter, WpfObjects.S5);
        libWpf.ButtonZweiBilder(1, 3, 12, 2, 10, "SchiebeSchalterOn.jpg", "SchiebeSchalterOff.jpg", buttonRand, vmKata.BtnSchalter, WpfObjects.S6);
        libWpf.ButtonZweiBilder(1, 3, 14, 2, 10, "KippSchalterOn.jpg", "KippSchalterOff.jpg", buttonRand, vmKata.BtnSchalter, WpfObjects.S7);
        libWpf.ButtonZweiBilder(1, 3, 16, 2, 10, "KippSchalterOn.jpg", "KippSchalterOff.jpg", buttonRand, vmKata.BtnSchalter, WpfObjects.S8);


        var kontakteRand = new Thickness(0, 5, 5, 5);

        libWpf.BildSichtbarkeitAus("TasterSchliesser.jpg", 5, 2, 1, 2, kontakteRand, WpfObjects.S1);
        libWpf.BildSichtbarkeitEin("TasterBetaetigt.jpg", 5, 2, 1, 2, kontakteRand, WpfObjects.S1);

        libWpf.BildSichtbarkeitAus("TasterSchliesser.jpg", 5, 2, 3, 2, kontakteRand, WpfObjects.S2);
        libWpf.BildSichtbarkeitEin("TasterBetaetigt.jpg", 5, 2, 3, 2, kontakteRand, WpfObjects.S2);

        libWpf.BildSichtbarkeitAus("TasterSchliesser.jpg", 5, 2, 5, 2, kontakteRand, WpfObjects.S3);
        libWpf.BildSichtbarkeitEin("TasterBetaetigt.jpg", 5, 2, 5, 2, kontakteRand, WpfObjects.S3);

        libWpf.BildSichtbarkeitAus("TasterSchliesser.jpg", 5, 2, 7, 2, kontakteRand, WpfObjects.S4);
        libWpf.BildSichtbarkeitEin("TasterBetaetigt.jpg", 5, 2, 7, 2, kontakteRand, WpfObjects.S4);

        libWpf.BildSichtbarkeitAus("TasterSchliesser.jpg", 5, 2, 10, 2, kontakteRand, WpfObjects.S5);
        libWpf.BildSichtbarkeitEin("TasterBetaetigt.jpg", 5, 2, 10, 2, kontakteRand, WpfObjects.S5);

        libWpf.BildSichtbarkeitAus("TasterSchliesser.jpg", 5, 2, 12, 2, kontakteRand, WpfObjects.S6);
        libWpf.BildSichtbarkeitEin("TasterBetaetigt.jpg", 5, 2, 12, 2, kontakteRand, WpfObjects.S6);

        libWpf.BildSichtbarkeitAus("TasterSchliesser.jpg", 5, 2, 14, 2, kontakteRand, WpfObjects.S7);
        libWpf.BildSichtbarkeitEin("TasterBetaetigt.jpg", 5, 2, 14, 2, kontakteRand, WpfObjects.S7);

        libWpf.BildSichtbarkeitAus("TasterSchliesser.jpg", 5, 2, 16, 2, kontakteRand, WpfObjects.S8);
        libWpf.BildSichtbarkeitEin("TasterBetaetigt.jpg", 5, 2, 16, 2, kontakteRand, WpfObjects.S8);


        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        libWpf.KreisStrokeMarginSetFilling(10, 2, 1, 2, kreisRandFarbe, kreisRand, WpfObjects.P1);
        libWpf.KreisStrokeMarginSetFilling(10, 2, 3, 2, kreisRandFarbe, kreisRand, WpfObjects.P2);
        libWpf.KreisStrokeMarginSetFilling(10, 2, 5, 2, kreisRandFarbe, kreisRand, WpfObjects.P3);
        libWpf.KreisStrokeMarginSetFilling(10, 2, 7, 2, kreisRandFarbe, kreisRand, WpfObjects.P4);
        libWpf.KreisStrokeMarginSetFilling(10, 2, 10, 2, kreisRandFarbe, kreisRand, WpfObjects.P5);
        libWpf.KreisStrokeMarginSetFilling(10, 2, 12, 2, kreisRandFarbe, kreisRand, WpfObjects.P6);
        libWpf.KreisStrokeMarginSetFilling(10, 2, 14, 2, kreisRandFarbe, kreisRand, WpfObjects.P7);
        libWpf.KreisStrokeMarginSetFilling(10, 2, 16, 2, kreisRandFarbe, kreisRand, WpfObjects.P8);


        libWpf.ButtonZweiBilder(20, 4, 15, 4, 10, "NotHalt.jpg", "NotHaltGedrueckt.jpg", new Thickness(0, 0, 0, 0), vmKata.BtnSchalter, WpfObjects.S3);



        libWpf.PlcError();
    }
}