using Services.DatabaseConnect.Sqlite.Entities;
using System.Data.Entity;

namespace Services.DatabaseConnect.Sqlite.Context {
    public class RootContext : DbContext {
        
        public DbSet<Language> Languages { get; set; }
    }
}
