using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTool.Domains.Entities {
    [Table("BasicTypes")]
    public class BasicType {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Index("IX_BasicTypeSearch", IsClustered = false, IsUnique = false, Order = 0)]
        public bool IsActivated { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Code", TypeName = "varchar")]
        [Index("IX_BasicTypeSearch", IsClustered = false, IsUnique = false, Order = 1)]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Name", TypeName = "varchar")]
        public string Name { get; set; }
    }
}
