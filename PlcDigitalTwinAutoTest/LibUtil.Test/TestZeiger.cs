﻿using Xunit;

namespace LibUtil.Test;

public class TestZeiger
{
    [Theory]
    [InlineData(0, 0, 0, 0, 0)]
    [InlineData(1, 1, 0, 0, 0)]
    [InlineData(1, 0, 1, 0, 0)]
    [InlineData(1, 0, 0, 1, 0)]
    [InlineData(1, 0, 0, 0, 1)]
    public void TestsZeigerKonstruktor(double exp, double x1, double y1, double x2, double y2)
    {
        var p1 = new Punkt(x1, y1);
        var p2 = new Punkt(x2, y2);

        var zeiger = new Zeiger(p1, p2);
        var res = zeiger.Laenge();

        Assert.Equal(exp, res, 3);
    }
}