﻿using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LibWpf;

public partial class LibWpf
{
    public void Rechteck(int xPos, int xSpan, int yPos, int ySpan, Brush farbe)
    {
        var rectangle = new Rectangle
        {
            Fill = farbe
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }

    public void RechteckFill(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, Thickness margin)
    {
        var rectangle = new Rectangle
        {
            Fill = fill,
            Margin = margin
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }

    public void RechteckFillStroke(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, SolidColorBrush stroke, double strokeThicknes, Thickness margin)
    {
        var rectangle = new Rectangle
        {
            Fill = fill,
            Stroke = stroke,
            StrokeThickness = strokeThicknes,
            Margin = margin
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }

    public void RechteckRand(int xPos, int xSpan, int yPos, int ySpan, Brush fill, object wpfId)
    {
        var rectangle = new Rectangle
        {
            Fill = fill
        };
        rectangle.SetMarginBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }

    public void RechteckVis(int xPos, int xSpan, int yPos, int ySpan, Brush rand, object wpfId)
    {
        var rectangle = new Rectangle
        {
            Stroke = rand
        };
        rectangle.SetFillingBinding(wpfId);
        rectangle.SetSichtbarkeitEinBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }

    public void RechteckFarbeUmschalten(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush stroke,
        Thickness margin, object wpfId)
    {
        var rectangle = new Rectangle
        {
            Stroke = stroke,
            Margin = margin,
            Fill = new SolidColorBrush(Colors.Red)
        };

        rectangle.SetFillingBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }

    public void RechteckRotieren(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, Thickness margin,
        object wpfId)
    {
        var rectangle = new Rectangle
        {
            Margin = margin,
            Fill = fill
        };

        var b = new Binding($"Winkel[{(int)wpfId}]");
        var rt = new RotateTransform();
        BindingOperations.SetBinding(rt, RotateTransform.AngleProperty, b);
        rectangle.RenderTransform = rt;

        rectangle.SetTransformOriginBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }

    public void RechteckRundung(int xPos, int xSpan, int yPos, int ySpan, double radiusX, double radiusY, SolidColorBrush fill, SolidColorBrush stroke, double strokeThicknes, Rect rect)
    {
        var rectangleGeometry = new RectangleGeometry
        {
            Rect = rect,
            RadiusX = radiusX,
            RadiusY = radiusY
        };

        var path = new Path
        {
            Fill = fill,
            Stroke = stroke,
            StrokeThickness = strokeThicknes,
            Data = rectangleGeometry
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, path);
    }
}