using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Duolingo.Entities {
    [Table("Histories")]
    public class History {
        public History() {
            HistoryDetails = new HashSet<HistoryDetail>();
        }

        [Key]
        [Column("Id", Order = 0, TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("CreatedDate", Order = 1, TypeName = "datetime")]
        [Index("IX_CreatedDate", IsClustered = false, IsUnique = true)]
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public virtual ICollection<HistoryDetail> HistoryDetails { get; set; }
    }
}
