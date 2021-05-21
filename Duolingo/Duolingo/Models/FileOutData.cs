using Duolingo.Entities;
using System.Collections.Generic;

namespace Duolingo.Models {
    public class FileOutData {
        public List<Topic> Topics { get; set; }
        public List<History> Histories { get; set; }
        public List<HistoryDetail> HistoryDetails { get; set; }

        public FileOutData() {
            Topics = new List<Topic>();
            Histories = new List<History>();
            HistoryDetails = new List<HistoryDetail>();
        }
    }
}
