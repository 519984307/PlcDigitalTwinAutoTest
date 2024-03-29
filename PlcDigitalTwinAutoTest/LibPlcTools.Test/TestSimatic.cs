﻿using Xunit;

namespace LibPlcTools.Test;

public class TestSimatic
{

    [Theory]
    [InlineData(0, 100, 0)]
    [InlineData(10, 100, 2765)]
    [InlineData(-10, 100, -2765)]
    [InlineData(1000, 100, 27648)]
    [InlineData(-1000, 100, -27648)]

    public void TestsAnalogToInt16(double analog, double scale, int siemens)
    {
        Assert.Equal(siemens, Simatic.Analog_2_Int16(analog, scale));
    }

    [Theory]
    [InlineData(0, 100, 0)]
    [InlineData(10, 100, 2765)]
    [InlineData(-10, 100, -2765)]
    [InlineData(1000, 100, 27648)]
    [InlineData(-1000, 100, -27648)]

    public void TestsAnalogToInt32(double analog, double scale, int siemens)
    {
        Assert.Equal(siemens, Simatic.Analog_2_Int32(analog, scale));
    }

    [Theory]
    [InlineData(0, 100, 0)]
    [InlineData(27648, 100, 100)]
    [InlineData(-27648, 100, -100)]

    public void TestsAnalogToToDouble(int analog, double scale, int siemens)
    {
        Assert.Equal(siemens, Simatic.Analog_2_Double(analog, scale), 3);
    }

    [Theory]
    [InlineData(0, -100, 100, 0)]
    [InlineData(100, -100, 100, 100)]
    [InlineData(-100, -100, 100, -100)]
    [InlineData(200, -100, 100, 100)]
    [InlineData(-200, -100, 100, -100)]

    public void TestsClamp(int wert, double min, double max, double exp)
    {
        Assert.Equal(exp, Simatic.Clamp(wert, min, max), 3);
    }





    // ACHTUNG: Siemens verwendet Big Endian!!

    [Theory]
    [InlineData(0, 0)]
    [InlineData(257, 1)]
    [InlineData(3840, 0)]
    [InlineData(65535, 255)]

    public void TestsGetLowByte(uint wert, byte exp)
    {
        Assert.Equal(exp, Simatic.Digital_GetLowByte(wert));
    }


    [Theory]
    [InlineData(0, 0)]
    [InlineData(256, 1)]
    [InlineData(3840, 15)]
    [InlineData(65535, 255)]

    public void TestsGetHighByte(uint wert, byte exp)
    {
        Assert.Equal(exp, Simatic.Digital_GetHighByte(wert));
    }


    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 0, 1)]
    [InlineData(0, 1, 256)]

    public void TestsGetCombineByte(byte low, byte high, uint exp)
    {
        Assert.Equal(exp, Simatic.Digital_CombineTwoByte(low, high));
    }

}