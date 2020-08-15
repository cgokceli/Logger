using System;

namespace Logger.Handlers.Db {
    public class LogItem {
        public LogItem() {

        }

        public LogItem(bool create) {
            if (create)
                this.TimeStamp = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
        public DateTime TimeStamp { get; }
    }
}
