using Services.DatabaseConnect.Sqlite.Entities;
using SQLite.CodeFirst;
using System.Data.Entity;

namespace Services.DatabaseConnect.Sqlite.Context {
    public class RootContext : DbContext {
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<RootContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
        public DbSet<Language> Languages { get; set; }
    }
}
