using MySql.Data.EntityFramework;
using System.Data.Entity;

namespace Duolingo.Entities {
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DuoContext : DbContext {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DuoContext() : base("DuoDb") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Topic>().MapToStoredProcedures();
            modelBuilder.Entity<Question>().MapToStoredProcedures();
        }
    }
}
