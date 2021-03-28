using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DatabaseSqlite.Entities {
    [Table("Languages", Schema = "gender")]
    public sealed class Language {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisallowNull]
        [Column("Id", TypeName = "INTEGER")]
        public long Id { get; set; }

        [DisallowNull]
        [Column("Name", TypeName = "TEXT(100)")]
        public string Name { get; set; }

        [DisallowNull]
        [Column("Version", TypeName = "TEXT(20)")]
        public string Version { get; set; }

        [DisallowNull]
        [Column("CreatedOn", TypeName = "TEXT(30)")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [DisallowNull]
        [Column("UpdatedOn", TypeName = "TEXT(30)")]
        public DateTime UpdatedOn { get; set; }

        [DisallowNull]
        [Column("IsActivated", TypeName = "INTEGER")]
        public bool IsActivated { get; set; }

        [Column("Description", TypeName = "TEXT(500)")]
        public string Description { get; set; }
    }
}
