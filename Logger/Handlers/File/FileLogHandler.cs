using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Logger.Handlers.File {
    public interface IFileLogHandler : ILogHandler {

    }

    public class FileLogHandler : IFileLogHandler {

        private static string GetDirectory => $"{AppContext.BaseDirectory}//logs";
        private static string GetSuffix(DateTime timeStamp) => $"{timeStamp.Year:0000}{timeStamp.Month:00}{timeStamp.Day:00}";

        private static string GetFullName(DateTime timeStamp) => Path.Combine(GetDirectory, $"log_{GetSuffix(timeStamp)}.txt");

        public FileLogHandler() {
            if (!Directory.Exists(GetDirectory))
                Directory.CreateDirectory(GetDirectory);
        }


        public bool TryAddLog(string message, object data) {
            try {
                var now = DateTime.UtcNow;

                var fullName = GetFullName(now);

                var builder = new StringBuilder();
                builder.Append(now.ToString("yyyy-MM-dd HH:mm:ss.fff zzz"));
                builder.Append(" [Message: ");
                builder.Append(message);
                builder.Append("] Data: ");
                builder.AppendLine(JsonSerializer.Serialize(data));

                using var streamWriter = System.IO.File.AppendText(fullName);
                streamWriter.Write(builder.ToString());

                return true;
            } catch (Exception e) {
                return false;
            }
        }
    }
}
