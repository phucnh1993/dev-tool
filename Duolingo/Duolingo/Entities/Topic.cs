using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Duolingo.Entities {
    [Table("Topics", Schema = "lin")]
    public class Topic {
        [Key]
        [Column("Id", Order = 0, TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "Title over max length")]
        [Column("Title", Order = 1, TypeName = "varchar")]
        public string Title { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "HashCompare over max length")]
        [Column("HashCompare", Order = 2, TypeName = "varchar")]
        public string HashCompare { get; set; }

        [Required]
        [Column("Sort", Order = 3, TypeName = "int")]
        public int Sort { get; set; }
    }
}
