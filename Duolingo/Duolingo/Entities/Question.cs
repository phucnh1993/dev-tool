using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Duolingo.Entities {
    [Table("Questions")]
    public class Question {
        [Key]
        [Column("Id", Order = 0, TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "EnglishData over max length")]
        [Column("EnglishData", Order = 1, TypeName = "varchar")]
        [Index("IX_EnglishData", IsClustered = false, IsUnique = true)]
        public string EnglishData { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage = "EnglishHashCompare over max length")]
        [Column("EnglishHashCompare", Order = 2, TypeName = "varchar")]
        [Index("IX_EnglishHashCompare", IsClustered = false, IsUnique = true)]
        public string EnglishHashCompare { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "VietnamData over max length")]
        [Column("VietnamData", Order = 3, TypeName = "nvarchar")]
        [Index("IX_VietnamData", IsClustered = false, IsUnique = true)]
        public string VietnamData { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage = "VietnamHashCompare over max length")]
        [Column("VietnamHashCompare", Order = 4, TypeName = "varchar")]
        [Index("IX_VietnamHashCompare", IsClustered = false, IsUnique = true)]
        public string VietnamHashCompare { get; set; }

        [Required]
        [Column("Sort", Order = 5, TypeName = "int")]
        public int Sort { get; set; }

        [Required]
        [Column("IsActivated", Order = 6, TypeName = "bool")]
        public bool IsActivated { get; set; }

        [Required]
        [Column("TopicId", Order = 7, TypeName = "bigint")]
        [InverseProperty("FK_Questions_TopicId")]
        [Index("IX_TopicId", IsClustered = false, IsUnique = true)]
        public long TopicId { get; set; }

        public virtual Topic MyTopic { get; set; }
    }
}
