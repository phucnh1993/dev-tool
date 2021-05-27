using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTool.Domains.Entities {
    [Table("ObjectGroups")]
    public class ObjectGroup {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Index("IX_DataTypeSearch", IsClustered = false, IsUnique = false, Order = 0)]
        public bool IsActivated { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("Name", TypeName = "varchar")]
        public string Name { get; set; }

        [MaxLength(2000)]
        [Column("Description", TypeName = "nvarchar")]
        public string Description { get; set; }

        public virtual ICollection<ObjectData> ObjectDatas { get; set; }
    }
}
