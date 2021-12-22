﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using static System.Windows.Controls.Grid;


namespace LibWpf;

public class LibTexte
{
    public static void Text(string text, int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Brush farbe, Grid grid)
    {
        var label = new Label
        {
            Content = text,
            FontSize = fontSize,
            Foreground = farbe,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical
        };

        GridAnpassen(xPos, xSpan, yPos, ySpan, grid, label);
    }
    public static void TextVis(int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Brush farbe, int wpfObject, Grid grid)
    {
        var label = new Label
        {
            FontSize = fontSize,
            Foreground = farbe,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical
        };

        label.SetBinding(ContentControl.ContentProperty, new Binding($"Text[{wpfObject }]"));
        label.SetBinding(UIElement.VisibilityProperty, new Binding($"SichtbarEin[{wpfObject}]"));

        GridAnpassen(xPos, xSpan, yPos, ySpan, grid, label);
    }

    public static void GridAnpassen(int xPos, int xSpan, int yPos, int ySpan, Grid grid, UIElement label)
    {
        SetColumn(label, xPos);
        SetColumnSpan(label, xSpan);
        SetRow(label, yPos);
        SetRowSpan(label, ySpan);
        grid.Children.Add(label);
    }
    
}