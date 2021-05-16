using Duolingo.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Duolingo.Views.ManageHistory {
    public partial class ManageHistory : Form {
        public ManageHistory() {
            InitializeComponent();
        }

        private void Reload(DateTime start, DateTime end) {
            if (start < end) {
                using (var db = new DuoContext()) {
                    var his = db.Histories.AsNoTracking().Where(x => x.CreatedDate >= start && x.CreatedDate <= end).ToList();
                    totalHistory.Text = his.Count.ToString();
                    listHistory.DataSource = null;
                    if (his.Count > 0) {
                        var hisSelect = his.Select(x => new HistorySelection() { Id = x.Id, CreatedDate = x.CreatedDate.ToString("yyyy/MM/dd") }).ToList();
                        listHistory.DataSource = hisSelect;
                        listHistory.DisplayMember = "CreatedDate";
                    }
                }
                return;
            }
            MessageBox.Show("Start Date and End Date invalid", "Date select not valid");
        }

        private void ManageHistory_Load(object sender, EventArgs e) {
            var end = DateTime.Now;
            var start = end.AddDays(-7);
            Reload(start, end);
            startDate.Value = start;
            endDate.Value = end;
            using (var db = new DuoContext()) {
                var topics = db.Topics.AsNoTracking().Where(x => !x.IsDeleted && !x.IsHide).OrderBy(x => x.Sort).ToList();
                selectTopic.DataSource = topics;
                selectTopic.DisplayMember = "Title";
            }
        }

        private void addHistory_Click(object sender, EventArgs e) {
            var now = DateTime.Now.Date;
            var nextDay = now.AddDays(1);
            var topic = (Topic) selectTopic.SelectedItem;
            using (var db = new DuoContext()) {
                History his;
                if (!db.Histories.Any(x => x.CreatedDate >= now && x.CreatedDate < nextDay)) {
                    his = new History() {
                        CreatedDate = now
                    };
                    db.Histories.Add(his);
                    db.SaveChanges();
                } else {
                    his = db.Histories.FirstOrDefault(x => x.CreatedDate >= now && x.CreatedDate < nextDay && !x.HistoryDetails.Any(y => y.TopicId == topic.Id));
                }
                if (his == null) {
                    MessageBox.Show("Chủ đề đã kiểm tra và thêm lịch sử", "Trùng lập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var hisDetail = new HistoryDetail() {
                    HistoryId = his.Id,
                    TopicId = topic.Id,
                    DataTest = new byte[0]
                };
                db.HistoryDetails.Add(hisDetail);
                db.SaveChanges();
                listTopic.DataSource = null;
                var hisDetails = db.HistoryDetails.AsNoTracking()
                       .Where(x => x.MyHistory.Id == his.Id)
                       .OrderBy(x => x.MyTopic.Sort)
                       .Select(x => new { Id = x.Id, Title = x.MyTopic.Title }).ToList();
                listTopic.DataSource = hisDetails;
                listTopic.DisplayMember = "Title";
            }
        }

        private void reload_Click(object sender, EventArgs e) {
            var start = startDate.Value;
            var end = endDate.Value;
            Reload(start, end);
        }

        private void listHistory_SelectedIndexChanged(object sender, EventArgs e) {
            listTopic.DataSource = null;
            var item = (HistorySelection) listHistory.SelectedItem;
            if (item != null && item.Id > 0) {
                using (var db = new DuoContext()) {
                    var hisDetail = db.HistoryDetails.AsNoTracking()
                        .Where(x => x.MyHistory.Id == item.Id)
                        .OrderBy(x => x.MyTopic.Sort)
                        .Select(x => new { Id = x.Id, Title = x.MyTopic.Title }).ToList();
                    listTopic.DataSource = hisDetail;
                    listTopic.DisplayMember = "Title";
                }
            }
        }
    }
}
