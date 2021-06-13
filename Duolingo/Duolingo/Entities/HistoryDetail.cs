using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Duolingo.Entities {
    [Table("HistoryDetails")]
    public class HistoryDetail {
        [Key]
        [Column("Id", Order = 0, TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [InverseProperty("FK_HistoryDetails_HistoryId")]
        [Column("HistoryId", Order = 1, TypeName = "bigint")]
        [Index("IX_HistoryId", IsClustered = false, IsUnique = false)]
        public long HistoryId { get; set; }

        [Required]
        [InverseProperty("FK_HistoryDetails_TopicId")]
        [Column("TopicId", Order = 2, TypeName = "bigint")]
        [Index("IX_TopicId", IsClustered = false, IsUnique = false)]
        public long TopicId { get; set; }

        [Required]
        [Column("DataTest", Order = 3, TypeName = "longblob")]
        public byte[] DataTest { get; set; }

        [JsonIgnore]
        public virtual History MyHistory { get; set; }
        [JsonIgnore]
        public virtual Topic MyTopic { get; set; }
    }
}
