﻿using LibPlcTools;
using SoftCircuits.Silk;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
    public void FuncSleep(FunctionEventArgs args) => Thread.Sleep((int) new ZeitDauer(args.Parameters[0].ToString()).DauerMs);
    public void FuncRestartStopwatch() => _stopwatch.Restart();
    public long GetElapsedMilliseconds() => _stopwatch.ElapsedMilliseconds;
}