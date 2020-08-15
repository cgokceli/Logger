namespace Logger.Handlers {
    public interface ILogHandler {
        bool TryAddLog(string message, object data);
    }
}
