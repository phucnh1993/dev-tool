using MySql.Data.EntityFramework;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace Duolingo.Entities {
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DuoContext : DbContext {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<HistoryDetail> HistoryDetails { get; set; }
        public DuoContext() : base("DuoDb") { }

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
