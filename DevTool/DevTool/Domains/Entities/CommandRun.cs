using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTool.Domains.Entities {
    public class CommandRun {
        public CommandRun() {
            AppRuns = new HashSet<AppRun>();
        }

        [Key]
        public long Id { get; set; }
        public string CommandContent { get; set; }
        public string CommandDecription { get; set; }

        [ForeignKey("FK_CommandRun_AppRun")]
        public virtual ICollection<AppRun> AppRuns { get; set; }
    }
}
