using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.DatabaseConnect.Sqlite.Entities {
    [Table("Languages", Schema = "master")]
    public sealed class Language {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "INTEGER")]
        public long Id { get; set; }

        [Required]
        [Column("Name", TypeName = "TEXT(100)")]
        public string Name { get; set; }

        [Required]
        [Column("Version", TypeName = "TEXT(20)")]
        public string Version { get; set; }

        [Required]
        [Column("CreatedOn", TypeName = "TEXT(30)")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        [Column("UpdatedOn", TypeName = "TEXT(30)")]
        public DateTime UpdatedOn { get; set; }

        [Required]
        [Column("IsActivated", TypeName = "INTEGER")]
        public bool IsActivated { get; set; }

        [Column("Description", TypeName = "TEXT(500)")]
        public string Description { get; set; }
    }
}
