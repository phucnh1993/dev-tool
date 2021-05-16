using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Domain {
    [Table("Tools")]
    public class Tool {
        [Key]
        [Column("Id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Name", TypeName = "nvarchar")]
        public string Name { get; set; }

        [MaxLength(500)]
        [Column("Description", TypeName = "nvarchar")]
        public string Description { get; set; }

        public int Sort { get; set; }

        public bool IsActivated { get; set; }
    }
}
