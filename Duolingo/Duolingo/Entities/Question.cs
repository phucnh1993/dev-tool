using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Duolingo.Entities {
    [Table("Questions", Schema = "lin")]
    public class Question {
        [Key]
        [Column("Id", Order = 0, TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "EnglishData over max length")]
        [Column("EnglishData", Order = 1, TypeName = "varchar")]
        public string EnglishData { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "EnglishHashCompare over max length")]
        [Column("EnglishHashCompare", Order = 2, TypeName = "varchar")]
        public string EnglishHashCompare { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "VietnamData over max length")]
        [Column("VietnamData", Order = 3, TypeName = "varchar")]
        public string VietnamData { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "VietnamHashCompare over max length")]
        [Column("VietnamHashCompare", Order = 4, TypeName = "varchar")]
        public string VietnamHashCompare { get; set; }

        [Required]
        [Column("Sort", Order = 5, TypeName = "int")]
        public int Sort { get; set; }

        [Required]
        [Column("Status", Order = 6, TypeName = "tinyint")]
        public byte Status { get; set; }
    }
}
