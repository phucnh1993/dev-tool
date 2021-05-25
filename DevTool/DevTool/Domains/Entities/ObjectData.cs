using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTool.Domains.Entities {
    [Table("ObjectDatas")]
    public class ObjectData {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Index("IX_ObjectDataSearch", IsClustered = false, IsUnique = false, Order = 0)]
        public bool IsActivated { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("Name", TypeName = "varchar")]
        public string Name { get; set; }

        [MaxLength(2000)]
        [Column("Description", TypeName = "nvarchar")]
        public string Description { get; set; }

        public virtual ICollection<ObjectField> ObjectFields { get; set; }

        public ObjectData() {
            ObjectFields = new HashSet<ObjectField>();
        }
    }
}
