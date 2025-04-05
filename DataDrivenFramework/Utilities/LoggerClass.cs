
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NLog;



namespace DataDrivenFramework.Utilities;

    public static class LoggerClass
    {
        public static readonly Logger logger  = NLog.LogManager.GetCurrentClassLogger();
          static string startupPath = Environment.CurrentDirectory;
        static LoggerClass()
        {
             String logFilePath = startupPath.Replace("bin\\Debug\\net8.0", "Resources\\Logs\\logfile.txt"); 

            //  NLog.LogManager.Setup().LoadConfiguration(builder => {
            // builder.ForLogger().FilterMinLevel(LogLevel.Info).WriteToConsole();
            // builder.ForLogger().FilterMinLevel(LogLevel.Debug).WriteToFile(fileName: logFilePath);
            // });  

            var config = new NLog.Config.LoggingConfiguration();
            
            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = logFilePath };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
                        
            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
                        
            // Apply config           
            NLog.LogManager.Configuration = config;   
            
        }



        public static void LogInfo(string message) => logger.Info(message);
        public static void LogError(string message) => logger.Error(message);
        public static void LogDebug(string message) => logger.Debug(message);
        public static void LogWarn(string message) => logger.Warn(message);
    }
