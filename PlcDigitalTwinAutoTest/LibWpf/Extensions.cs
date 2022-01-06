﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;

namespace LibWpf;

public static class Extensions
{
    public static void SetIsEnabledBinding(this FrameworkElement element, object wpfId) => element.SetBinding(UIElement.IsEnabledProperty, $"ButtonIsEnabled[{(int)wpfId}]");
    public static void SetBtnContentBinding(this Button element, object wpfId) => element.SetBinding(ContentControl.ContentProperty, $"Text[{(int)wpfId}]");
    public static void SetContentBinding(this ContentControl element, object wpfId) => element.SetBinding(ContentControl.ContentProperty, $"Text[{(int)wpfId}]");
    public static void SetBtnClickModeBinding(this Button element, object wpfId) => element.SetBinding(ButtonBase.ClickModeProperty, $"ClkMode[{(int)wpfId}]");
    public static void SetSichtbarkeitEinBinding(this FrameworkElement element, object wpfId) => element.SetBinding(UIElement.VisibilityProperty, $"SichtbarEin[{(int)wpfId}]");
    public static void SetSichtbarkeitAusBinding(this FrameworkElement element, object wpfId) => element.SetBinding(UIElement.VisibilityProperty, $"SichtbarAus[{(int)wpfId}]");
    public static void SetTextBlockBinding(this TextBlock element, object wpfId) => element.SetBinding(TextBlock.TextProperty, $"Text[{(int)wpfId}]");
    public static void SetFillingBinding(this Shape element, object wpfId) => element.SetBinding(Shape.FillProperty, $"Farbe[{(int)wpfId}]");
}