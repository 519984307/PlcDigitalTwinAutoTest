﻿using System.Threading;

namespace BasePlcDtAt.BaseModel;

public abstract class BaseModel
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    protected abstract void ModelThread();
    

    protected BaseModel()
    {
        Log.Debug("Konstruktor - startet");
        System.Threading.Tasks.Task.Run(ModelTask);
    }

    protected void ModelTask()
    {
        while (true)
        {
            ModelThread();
            Thread.Sleep(10);
        }
        // ReSharper disable once FunctionNeverReturns
    }
}