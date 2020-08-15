using Logger.Handlers.Db;
using Logger.Handlers.File;
using System;
using System.Text.Json;

namespace Logger {

    public class Logger : ILogger {
        private readonly IDbLogHandler _dbLogger;
        private readonly IFileLogHandler _fileLogger;

        private readonly Action<string, object> LogFallback = (message, obj) => {
            Console.WriteLine($"Logging failed, falling back to console.{Environment.NewLine}Message: {message}{Environment.NewLine}Data:{JsonSerializer.Serialize(obj)}");
        };

        public Logger(IDbLogHandler dbLogger, IFileLogHandler fileLogger) {
            this._dbLogger = dbLogger;
            this._fileLogger = fileLogger;
        }

        public void Add(string message, object obj) {
            try {
                var isOk = this._dbLogger.TryAddLog(message, obj);
                if (!isOk)
                    isOk = this._fileLogger.TryAddLog(message, obj);
                if (!isOk)
                    LogFallback(message, obj);
            } catch (Exception) {
                LogFallback(message, obj);
            }
        }
    }
}
