using DevTool.Domains.Entities;
using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTool.Domains {
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ToolContext : DbContext {
        public DbSet<Language> Languages { get; set; }

        public ToolContext() : base() {}

        public ToolContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection) {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Language>().MapToStoredProcedures();
        }
    }
}
