using Microsoft.EntityFrameworkCore;
using System;

namespace Logger.Handlers.Db {
    public class LogContext : DbContext {

        public DbSet<LogItem> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            var filePath = System.IO.Path.Combine(AppContext.BaseDirectory, "logs.db");
            options.UseSqlite($"Data Source={filePath};Mode=ReadWriteCreate;");
        }

        protected override void OnModelCreating(ModelBuilder builder) => builder.Entity<LogItem>(entity => { entity.ToTable("Logs"); });

    }

    public class LogContextFactory {
        private bool _initialized;

        public LogContext Create() {
            if (_initialized)
                return new LogContext();

            var context = new LogContext();
            context.Database.Migrate();
            context.Database.EnsureCreated();

            _initialized = true;

            return context;
        }
    }
}
