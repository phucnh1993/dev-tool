using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Duolingo.Entities {
    [Table("Topics")]
    public class Topic {
        public Topic() {
            Questions = new HashSet<Question>();
            HistoryDetails = new HashSet<HistoryDetail>();
        }

        [Key]
        [Column("Id", Order = 0, TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "Title over max length")]
        [Column("Title", Order = 1, TypeName = "nvarchar")]
        public string Title { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "HashCompare over max length")]
        [Column("HashCompare", Order = 2, TypeName = "varchar")]
        public string HashCompare { get; set; }

        [Required]
        [Column("Sort", Order = 3, TypeName = "int")]
        public int Sort { get; set; }

        [Required]
        [Column("IsActivated", Order = 4, TypeName = "bool")]
        public bool IsActivated { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<HistoryDetail> HistoryDetails { get; set; }
    }
}
