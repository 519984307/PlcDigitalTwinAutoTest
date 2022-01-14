﻿using System.Threading;
using LibPlcTools;
using SoftCircuits.Silk;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    public  void Sleep(FunctionEventArgs e)
    {
        var sleepTime = new ZeitDauer(e.Parameters[0].ToString());
        Thread.Sleep((int)sleepTime.DauerMs);
    }
    private  void ResetStopwatch() => SilkStopwatch.Restart();
}