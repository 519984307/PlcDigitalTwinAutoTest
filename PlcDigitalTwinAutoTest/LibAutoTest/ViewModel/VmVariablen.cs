﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace LibAutoTest.ViewModel;

public partial class VmAutoTest
{
    [ObservableProperty] private bool _enableTasterStart;
    [ObservableProperty] private bool _checkboxTasterEinzelschritt;

    [ObservableProperty] private ClickMode _clickModeStart;
    [ObservableProperty] private ClickMode _clickModeEinzelSchritt;

    [ObservableProperty] private Visibility _visibilityTabAutoTest;
    [ObservableProperty] private Visibility _visibilityTasterStart;
    [ObservableProperty] private Visibility _visibilityTasterEinzelschritt;
    [ObservableProperty] private Visibility _visibilityTabSoftwareTest; // todo? warum kummt des döt vor

    [ObservableProperty] private string _stringTasterStart;
}
