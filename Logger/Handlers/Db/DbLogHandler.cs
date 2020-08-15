using System;
using System.Text.Json;

namespace Logger.Handlers.Db {
    public interface IDbLogHandler : ILogHandler {

    }

    public class DbLogHandler : IDbLogHandler {
        private readonly LogContextFactory _contextFactory;

        public DbLogHandler(LogContextFactory contextFactory) {
            this._contextFactory = contextFactory;
        }

        public bool TryAddLog(string message, object data) {
            try {
                using var context = this._contextFactory.Create();
                context.Logs.Add(new LogItem(true) {
                    Data = JsonSerializer.Serialize(data),
                    Message = message
                });
                return context.SaveChanges() > 0;
            } catch (Exception e) {
                return false;
            }
        }
    }
}
