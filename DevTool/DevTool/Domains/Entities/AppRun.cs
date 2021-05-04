using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevTool.Domains.Entities {
    public class AppRun {
        public AppRun() {
            CommandRuns = new HashSet<CommandRun>();
        }

        [Key]
        public long Id { get; set; }
        public string AppName { get; set; }
        public string AppType { get; set; }

        public virtual ICollection<CommandRun> CommandRuns { get; set; }
    }
}
