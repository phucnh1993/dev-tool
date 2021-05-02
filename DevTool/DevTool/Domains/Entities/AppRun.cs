using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTool.Domains.Entities {
    public class AppRun {
        public AppRun() {
            CommandRuns = new HashSet<CommandRun>();
        }

        [Key]
        public long Id { get; set; }
        public string AppName { get; set; }
        public string AppType { get; set; }

        [ForeignKey("FK_AppRun_CommandRun")]
        public virtual ICollection<CommandRun> CommandRuns { get; set; }
    }
}
