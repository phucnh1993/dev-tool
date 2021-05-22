using DevTool.Domains.Entities;
using MySql.Data.EntityFramework;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace DevTool.Domains {
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class CreatorContext : DbContext {

        public DbSet<Function> Functions { get; set; }
        public DbSet<Category> Categories { get; set; }

        public CreatorContext() : base("CreatorContext") { }

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
