using Newtonsoft.Json;
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
        [MaxLength(100, ErrorMessage = "Title over max length")]
        [Column("Title", Order = 1, TypeName = "nvarchar")]
        public string Title { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage = "HashCompare over max length")]
        [Column("HashCompare", Order = 2, TypeName = "varchar")]
        public string HashCompare { get; set; }

        [Required]
        [Column("Sort", Order = 3, TypeName = "int")]
        public int Sort { get; set; }

        [Required]
        [Column("IsHide", Order = 4)]
        public bool IsHide { get; set; }

        [Required]
        [Column("IsDeleted", Order = 5)]
        public bool IsDeleted { get; set; }

        [JsonIgnore]
        public virtual ICollection<Question> Questions { get; set; }
        [JsonIgnore]
        public virtual ICollection<HistoryDetail> HistoryDetails { get; set; }
    }
}
