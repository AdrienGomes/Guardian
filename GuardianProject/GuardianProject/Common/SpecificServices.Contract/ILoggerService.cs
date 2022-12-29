﻿namespace GuardianProject.Common.SpecificServices.Contract
{
    /// <summary>
    /// Interface responsible for displaying the message
    /// </summary>
    public interface ILogger
    {
        void Trace(string text, params object[] args);
        void Debug(string text, params object[] args);
        void Info(string text, params object[] args);
        void Warn(string text, params object[] args);
        void Error(string text, params object[] args);
        void Fatal(string text, params object[] args);
    }

    /// <summary>
    /// Interface responsible for creating a <see cref="ILogger"/>
    /// </summary>
    public interface ILogManager
    {
        ILogger GetLog([System.Runtime.CompilerServices.CallerFilePath] string callerFilePath = "");
    }
}
