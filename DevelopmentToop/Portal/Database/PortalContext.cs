using MySql.Data.EntityFramework;
using Portal.Domain;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace Portal.Database {
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class PortalContext : DbContext {
        public DbSet<Tool> Tools { get; set; }

        public PortalContext() : base("PortalConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }

        public bool Update<T>(T data) {
            try {
                this.Entry(data).State = EntityState.Modified;
                this.SaveChanges();
                return true;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Lỗi update dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
