using DatabaseSqlite.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;

namespace DatabaseSqlite.Configs.Contexts {
    public class GenderContext : DbContext {
        public DbSet<Language> Languages { get; set; }

        public GenderContext(string dbFilePath) :
            base(
                new SQLiteConnection() {
                    ConnectionString = new SQLiteConnectionStringBuilder() {
                        DataSource = dbFilePath,
                        ForeignKeys = true
                    }.ConnectionString
                },
                true) { 

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
