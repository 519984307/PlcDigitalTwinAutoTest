﻿using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LibWpf;

public partial class LibWpf
{
    public void Polygon(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, SolidColorBrush stroke, double strokeThickness, double[][] punkte)
    {
        var polyPoints = new PointCollection();
        foreach (var punkt in punkte) polyPoints.Add(new System.Windows.Point(punkt[0], punkt[1]));

        var polygon = new Polygon
        {
            Fill = fill,
            Stroke = stroke,
            StrokeThickness = strokeThickness,
            Points = polyPoints
        };
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, polygon);
    }
    public void PolygonSetMargin(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, SolidColorBrush stroke, double strokeThickness, double[][] punkte, string bindingMargin)
    {
        var polyPoints = new PointCollection();
        foreach (var punkt in punkte) polyPoints.Add(new System.Windows.Point(punkt[0], punkt[1]));

        var polygon = new Polygon
        {
            Fill = fill,
            Stroke = stroke,
            StrokeThickness = strokeThickness,
            Points = polyPoints
        };
        polygon.BindingSetMargin(bindingMargin);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, polygon);
    }
    public void PolygonSetWinkel(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, SolidColorBrush stroke, double strokeThickness, double[][] punkte, string bindingWinkel)
    {
        var polyPoints = new PointCollection();
        foreach (var punkt in punkte) polyPoints.Add(new System.Windows.Point(punkt[0], punkt[1]));

        var polygon = new Polygon
        {
            Fill = fill,
            Stroke = stroke,
            StrokeThickness = strokeThickness,
            Points = polyPoints,
            RenderTransformOrigin = new System.Windows.Point(0.5, 0.5)
        };

        var b = new Binding($"{bindingWinkel}");
        var rt = new RotateTransform();
        BindingOperations.SetBinding(rt, RotateTransform.AngleProperty, b);
        polygon.RenderTransform = rt;

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, polygon);
    }
}