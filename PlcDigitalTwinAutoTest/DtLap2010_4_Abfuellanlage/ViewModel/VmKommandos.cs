﻿using Microsoft.Toolkit.Mvvm.Input;

namespace DtLap2010_4_Abfuellanlage.ViewModel;

public partial class VmLap2010
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        { }
    }

    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        switch (schalter)
        {  }
    }
}
