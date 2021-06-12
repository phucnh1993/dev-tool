using DevTool.Domains.Entities;
using MySql.Data.EntityFramework;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace DevTool.Domains {
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class CreatorContext : DbContext {
        /// <summary>
        /// Danh mục dữ liệu, enum, constant
        /// </summary>
        public DbSet<Category> Categories { get; set; }
        /// <summary>
        /// Kiểu dữ liệu (STRING, NUMBER)
        /// </summary>
        public DbSet<DataType> DataTypes { get; set; }
        /// <summary>
        /// Field - Property của một class
        /// </summary>
        //public DbSet<ObjectField>ObjectFields { get; set; }
        /// <summary>
        /// Table - Class : Một đối tượng
        /// </summary>
        //public DbSet<ObjectData> ObjectDatas { get; set; }
        /// <summary>
        /// Nhóm đối tượng (Dễ tìm kiếm)
        /// </summary>
        //public DbSet<ObjectGroup> ObjectGroups { get; set; }
        /// <summary>
        /// Hàm thực thi
        /// </summary>
        //public DbSet<Function> Functions { get; set; }
        /// <summary>
        /// Param truyền vào function
        /// </summary>
        //public DbSet<FunctionInput> FunctionInputs { get; set; }
        /// <summary>
        /// Param trả về của function
        /// </summary>
        //public DbSet<FunctionOutput> FunctionOutputs { get; set; }

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
