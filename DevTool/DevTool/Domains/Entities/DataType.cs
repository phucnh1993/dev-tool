using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTool.Domains.Entities {
    [Table("DataTypes")]
    public class DataType {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Index("IX_DataTypeSearch", IsClustered = false, IsUnique = false, Order = 0)]
        public bool IsActivated { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Code", TypeName = "varchar")]
        [Index("IX_DataTypeSearch", IsClustered = false, IsUnique = false, Order = 1)]
        public string Code { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("Name", TypeName = "varchar")]
        public string Name { get; set; }

        [Required]
        public int MaxLength { get; set; }

        [MaxLength(2000)]
        [Column("Description", TypeName = "nvarchar")]
        public string Description { get; set; }

        public int Sort { get; set; }

        //public virtual ICollection<ObjectField> ObjectFields { get; set; }

        public DataType() {
            //ObjectFields = new HashSet<ObjectField>();
        }
    }
}
