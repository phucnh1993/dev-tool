using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevTool.Domains.Entities {
    public class CommandRun {
        public CommandRun() {
            AppRuns = new HashSet<AppRun>();
        }

        [Key]
        public long Id { get; set; }
        public string CommandContent { get; set; }
        public string CommandDecription { get; set; }
        public int Sort { get; set; }

        public virtual ICollection<AppRun> AppRuns { get; set; }
    }
}
