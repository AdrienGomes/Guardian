using GuardianProject.Common.SpecificServices.Contract;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(GuardianProject.Droid.SpecificServices.SpecificServices.Services.NLogManager))]
namespace GuardianProject.Droid.SpecificServices.SpecificServices.Services
{
    public class NLogManager : ILogManager
    {
        public NLogManager()
        {
            LoggingConfiguration config = new LoggingConfiguration();

            ConsoleTarget consoleTarget = new ConsoleTarget();
            config.AddTarget("console", consoleTarget);

            LoggingRule consoleRule = new LoggingRule("*", LogLevel.Trace, consoleTarget);
            config.LoggingRules.Add(consoleRule);

            FileTarget fileTarget = new FileTarget();
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            fileTarget.FileName = Path.Combine(folder, "Log.txt");
            config.AddTarget("file", fileTarget);

            LoggingRule fileRule = new LoggingRule("*", LogLevel.Warn, fileTarget);
            config.LoggingRules.Add(fileRule);

            LogManager.Configuration = config;
        }

        public Common.SpecificServices.Contract.ILogger GetLog([System.Runtime.CompilerServices.CallerFilePath] string callerFilePath = "")
        {
            string fileName = callerFilePath;

            if (fileName.Contains("/"))
            {
                fileName = fileName[(fileName.LastIndexOf("/", StringComparison.CurrentCultureIgnoreCase) + 1)..];
            }

            Logger logger = LogManager.GetLogger(fileName);
            return new NLogLogger(logger);
        }
    }

    public class NLogLogger : GuardianProject.Common.SpecificServices.Contract.ILogger
    {
        private readonly Logger log;

        public NLogLogger(Logger log)
        {
            this.log = log;
        }

        public void Debug(string text, params object[] args)
        {
            log.Debug(text, args);
        }

        public void Error(string text, params object[] args)
        {
            log.Error(text, args);
        }

        public void Fatal(string text, params object[] args)
        {
            log.Fatal(text, args);
        }

        public void Info(string text, params object[] args)
        {
            log.Info(text, args);
        }

        public void Trace(string text, params object[] args)
        {
            log.Trace(text, args);
        }

        public void Warn(string text, params object[] args)
        {
            log.Warn(text, args);
        }
    }
}