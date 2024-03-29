﻿using System.Windows;
using System.Windows.Media;

namespace LibDisplayPlc.ViewModel;

public partial class VmPlc
{
    public VmDatenpunkte[] DaCollection { get; set; } = new VmDatenpunkte[20];
    public VmDatenpunkte[] DiCollection { get; set; } = new VmDatenpunkte[20];

    private void AlleDpInitialisieren()
    {
        for (var i = 0; i < 20; i++)
        {
            DaCollection[i] = new VmDatenpunkte(Brushes.Black, "", "", Visibility.Collapsed);
            DiCollection[i] = new VmDatenpunkte(Brushes.Black, "", "", Visibility.Collapsed);
        }
    }
    private void AlleDpAktualisieren()
    {
        (BrushDa00, StringBezeichnungDa00, StringKommentarDa00, VisibilityDa00) = DaCollection[0].GetDatenpunkt();
        (BrushDa01, StringBezeichnungDa01, StringKommentarDa01, VisibilityDa01) = DaCollection[1].GetDatenpunkt();
        (BrushDa02, StringBezeichnungDa02, StringKommentarDa02, VisibilityDa02) = DaCollection[2].GetDatenpunkt();
        (BrushDa03, StringBezeichnungDa03, StringKommentarDa03, VisibilityDa03) = DaCollection[3].GetDatenpunkt();
        (BrushDa04, StringBezeichnungDa04, StringKommentarDa04, VisibilityDa04) = DaCollection[4].GetDatenpunkt();
        (BrushDa05, StringBezeichnungDa05, StringKommentarDa05, VisibilityDa05) = DaCollection[5].GetDatenpunkt();
        (BrushDa06, StringBezeichnungDa06, StringKommentarDa06, VisibilityDa06) = DaCollection[6].GetDatenpunkt();
        (BrushDa07, StringBezeichnungDa07, StringKommentarDa07, VisibilityDa07) = DaCollection[7].GetDatenpunkt();
        (BrushDa10, StringBezeichnungDa10, StringKommentarDa10, VisibilityDa10) = DaCollection[10].GetDatenpunkt();
        (BrushDa11, StringBezeichnungDa11, StringKommentarDa11, VisibilityDa11) = DaCollection[11].GetDatenpunkt();
        (BrushDa12, StringBezeichnungDa12, StringKommentarDa12, VisibilityDa12) = DaCollection[12].GetDatenpunkt();
        (BrushDa13, StringBezeichnungDa13, StringKommentarDa13, VisibilityDa13) = DaCollection[13].GetDatenpunkt();
        (BrushDa14, StringBezeichnungDa14, StringKommentarDa14, VisibilityDa14) = DaCollection[14].GetDatenpunkt();
        (BrushDa15, StringBezeichnungDa15, StringKommentarDa15, VisibilityDa15) = DaCollection[15].GetDatenpunkt();
        (BrushDa16, StringBezeichnungDa16, StringKommentarDa16, VisibilityDa16) = DaCollection[16].GetDatenpunkt();
        (BrushDa17, StringBezeichnungDa17, StringKommentarDa17, VisibilityDa17) = DaCollection[17].GetDatenpunkt();

        (BrushDi00, StringBezeichnungDi00, StringKommentarDi00, VisibilityDi00) = DiCollection[0].GetDatenpunkt();
        (BrushDi01, StringBezeichnungDi01, StringKommentarDi01, VisibilityDi01) = DiCollection[1].GetDatenpunkt();
        (BrushDi02, StringBezeichnungDi02, StringKommentarDi02, VisibilityDi02) = DiCollection[2].GetDatenpunkt();
        (BrushDi03, StringBezeichnungDi03, StringKommentarDi03, VisibilityDi03) = DiCollection[3].GetDatenpunkt();
        (BrushDi04, StringBezeichnungDi04, StringKommentarDi04, VisibilityDi04) = DiCollection[4].GetDatenpunkt();
        (BrushDi05, StringBezeichnungDi05, StringKommentarDi05, VisibilityDi05) = DiCollection[5].GetDatenpunkt();
        (BrushDi06, StringBezeichnungDi06, StringKommentarDi06, VisibilityDi06) = DiCollection[6].GetDatenpunkt();
        (BrushDi07, StringBezeichnungDi07, StringKommentarDi07, VisibilityDi07) = DiCollection[7].GetDatenpunkt();
        (BrushDi10, StringBezeichnungDi10, StringKommentarDi10, VisibilityDi10) = DiCollection[10].GetDatenpunkt();
        (BrushDi11, StringBezeichnungDi11, StringKommentarDi11, VisibilityDi11) = DiCollection[11].GetDatenpunkt();
        (BrushDi12, StringBezeichnungDi12, StringKommentarDi12, VisibilityDi12) = DiCollection[12].GetDatenpunkt();
        (BrushDi13, StringBezeichnungDi13, StringKommentarDi13, VisibilityDi13) = DiCollection[13].GetDatenpunkt();
        (BrushDi14, StringBezeichnungDi14, StringKommentarDi14, VisibilityDi14) = DiCollection[14].GetDatenpunkt();
        (BrushDi15, StringBezeichnungDi15, StringKommentarDi15, VisibilityDi15) = DiCollection[15].GetDatenpunkt();
        (BrushDi16, StringBezeichnungDi16, StringKommentarDi16, VisibilityDi16) = DiCollection[16].GetDatenpunkt();
        (BrushDi17, StringBezeichnungDi17, StringKommentarDi17, VisibilityDi17) = DiCollection[17].GetDatenpunkt();
    }
}
public class VmDatenpunkte
{
    public Brush DpFarbe;
    public string DpBezeichnung;
    public string DpKommentar;
    public Visibility DpVisibility;

    public (Brush farbe, string bezeichnung, string kommentar, Visibility visibility) GetDatenpunkt() => (DpFarbe, DpBezeichnung, DpKommentar, DpVisibility);
    public VmDatenpunkte(Brush farbe, string stringBezeichnung, string stringKommentar, Visibility visibility)
    {
        DpFarbe = farbe;
        DpBezeichnung = stringBezeichnung;
        DpKommentar = stringKommentar;
        DpVisibility = visibility;
    }
}