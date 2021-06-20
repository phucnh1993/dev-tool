using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTool.Domains.Entities {
    [Table("FunctionOutputs")]
    public class FunctionOutput {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("DataType", TypeName = "varchar")]
        public string DataType { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("Name", TypeName = "varchar")]
        public string Name { get; set; }

        [MaxLength(2000)]
        [Column("Description", TypeName = "nvarchar")]
        public string Description { get; set; }

        [Required]
        [Index("IX_FunctionInputSearch", IsClustered = false, IsUnique = false, Order = 0)]
        public long FunctionId { get; set; }

        [Required]
        [Index("IX_FunctionInputSearch", IsClustered = false, IsUnique = false, Order = 1)]
        public bool IsActivated { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public virtual Function RootFunction { get; set; }
    }
}
