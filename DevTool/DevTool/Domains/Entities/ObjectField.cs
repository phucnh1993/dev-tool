using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTool.Domains.Entities {
    [Table("ObjectFields")]
    public class ObjectField {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Index("IX_ObjectFieldSearch", IsClustered = false, IsUnique = false, Order = 0)]
        public bool IsActivated { get; set; }

        [Required]
        public bool IsNull { get; set; }

        [Required]
        public int DataTypeId { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("Name", TypeName = "varchar")]
        public string Name { get; set; }

        [MaxLength(2000)]
        [Column("Description", TypeName = "nvarchar")]
        public string Description { get; set; }

        public virtual DataType DataType { get; set; }

        public virtual ICollection<ObjectData> ObjectDatas { get; set; }
        public ObjectField() {
            ObjectDatas = new HashSet<ObjectData>();
        }
    }
}
