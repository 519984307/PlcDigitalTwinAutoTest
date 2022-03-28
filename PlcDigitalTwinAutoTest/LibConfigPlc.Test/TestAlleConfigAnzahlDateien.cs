﻿using Xunit;

namespace LibConfigPlc.Test;

public class TestAlleConfigAnzahlDateien
{

    [Fact]
    public void UnbekannterOrdnerTesten()
    {
        var config = new ConfigPlc("NichtVorhandenerPfad");

        Assert.False(config.Di.ConfigOk);
        Assert.False(config.Da.ConfigOk);
        Assert.False(config.Ai.ConfigOk);
        Assert.False(config.Aa.ConfigOk);

        Assert.Equal(0, config.Di.AnzZeilen);
        Assert.Equal(0, config.Da.AnzZeilen);
        Assert.Equal(0, config.Ai.AnzZeilen);
        Assert.Equal(0, config.Aa.AnzZeilen);
    }
}