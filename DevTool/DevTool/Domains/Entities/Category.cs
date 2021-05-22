using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTool.Domains.Entities {
    [Table("Categories")]
    public class Category {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(1000)]
        [Column("Name", TypeName = "nvarchar")]
        [Index("IX_CategorySearch", IsClustered = false, IsUnique = false, Order = 1)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int Sort { get; set; }

        [Required]
        [Index("IX_CategorySearch", IsClustered = false, IsUnique = false, Order = 0)]
        public bool IsActivated { get; set; }

        [MaxLength(2000)]
        [Column("Description", TypeName = "nvarchar")]
        public string Description { get; set; }

        [Column("CategoryData", TypeName = "longblob")]
        public byte[] CategoryData { get; set; }

        public long? GroupId { get; set; }

        [JsonIgnore]
        public virtual Category GroupParent { get; set; }

        [JsonIgnore]
        public virtual ICollection<Category> Children { get; set; }

        public Category() {
            Children = new HashSet<Category>();
        }
    }
}
