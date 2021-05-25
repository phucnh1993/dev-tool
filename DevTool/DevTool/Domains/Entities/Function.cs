using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTool.Domains.Entities {
    [Table("Functions")]
    public class Function {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("CodeSupport", TypeName = "varchar")]
        [Index("IX_FunctionSearch", IsClustered = false, IsUnique = false, Order = 1)]
        public string CodeSupport { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("Name", TypeName = "varchar")]
        [Index("IX_FunctionSearch", IsClustered = false, IsUnique = false, Order = 2)]
        public string Name { get; set; }

        [Required]
        [MaxLength(64)]
        [Column("HashData", TypeName = "varchar")]
        [Index("IX_FunctionHashData", IsClustered = false, IsUnique = true)]
        public string HashData { get; set; }

        [MaxLength(2000)]
        [Column("Description", TypeName = "nvarchar")]
        public string Description { get; set; }

        [Required]
        [Column("FunctionData", TypeName = "longblob")]
        public byte[] FunctionData { get; set; }

        [Required]
        [Index("IX_FunctionSearch", IsClustered = false, IsUnique = false, Order = 0)]
        public bool IsActivated { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<FunctionInput> FunctionInput { get; set; }
        public virtual ICollection<FunctionOutput> FunctionOutput { get; set; }

        public Function() {
            FunctionInput = new HashSet<FunctionInput>();
            FunctionOutput = new HashSet<FunctionOutput>();
        }
    }
}
