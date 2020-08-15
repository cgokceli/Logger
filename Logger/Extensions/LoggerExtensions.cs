using Logger.Handlers.Db;
using Logger.Handlers.File;
using Microsoft.Extensions.DependencyInjection;

namespace Logger.Extensions {
    public static class LoggerExtensions {
        public static IServiceCollection AddCustomLogging(this IServiceCollection container) {
            return container
                   .AddSingleton<LogContextFactory>()
                   .AddSingleton<IDbLogHandler, DbLogHandler>()
                   .AddSingleton<IFileLogHandler, FileLogHandler>()
                   .AddSingleton<ILogger, Logger>();
        }
    }
}
