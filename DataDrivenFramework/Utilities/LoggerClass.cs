
using NLog;
using NLog.Config;



namespace DataDrivenFramework.Utilities;

    public static class LoggerClass
    {
        private static readonly Logger logger  = NLog.LogManager.GetCurrentClassLogger();
        static string startupPath = Environment.CurrentDirectory;
        static LoggerClass()
        {
             String logFilePath = startupPath.Replace("bin\\Debug\\net8.0", "Resources\\Logs\\"); 

             NLog.LogManager.Setup().LoadConfiguration(builder => {
          //  builder.Configuration = new XmlLoggingConfiguration( logFilePath + "NLog.config");
            builder.ForLogger().FilterMinLevel(LogLevel.Info).WriteToConsole();
            builder.ForLogger().FilterMinLevel(LogLevel.Debug).WriteToFile(fileName: logFilePath + "logfile"+GetDateString+".txt");
            });          
            
        }

        private static string GetDateString => DateTime.Now.ToString("yyyy-MM-dd");


        public static void LogInfo(string message) => logger.Info(message);
        public static void LogError(string message, Exception? ex = null) 
        {
             if (ex != null)
            logger.Error(ex, message);
        else
            logger.Error(message);
        }
                
        public static void LogDebug(string message) => logger.Debug(message);
        public static void LogWarn(string message) => logger.Warn(message);
    }
