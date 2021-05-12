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
                    var his = db.Histories.Where(x => x.CreatedDate >= start && x.CreatedDate <= end).ToList();
                    totalHistory.Text = his.Count.ToString();
                    listHistory.Items.Clear();
                    if (his.Count > 0) {
                        foreach (var item in his) {
                            string dataHis = item.Id + ": " + item.CreatedDate.ToString("yyyy/MM/dd");
                            listHistory.Items.Add(dataHis);
                        }
                    }
                    var topics = db.Topics.AsNoTracking().Where(x => !x.IsDeleted && !x.IsHide).OrderBy(x => x.Sort).ToList();
                    selectTopic.DataSource = topics;
                    selectTopic.DisplayMember = "Title";
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
        }

        private void addHistory_Click(object sender, EventArgs e) {
            var now = DateTime.Now.Date;
            var nextDay = now.AddDays(1);
            using (var db = new DuoContext()) {
                if (!db.Histories.Any(x => x.CreatedDate >= now && x.CreatedDate < nextDay)) {
                    var his = new History() {
                        CreatedDate = now
                    };
                    db.Histories.Add(his);
                    db.SaveChanges();
                } else {
                    var topic = (Topic) selectTopic.SelectedItem;
                    var topicId = topic.Id;
                    var his = db.Histories.FirstOrDefault(x => x.CreatedDate >= now && x.CreatedDate < nextDay && !x.HistoryDetails.Any(y => y.TopicId == topicId));
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
                }
                listTopic.Items.Clear();
            }
        }

        private void reload_Click(object sender, EventArgs e) {
            var start = startDate.Value;
            var end = endDate.Value;
            Reload(start, end);
        }

        private void listHistory_SelectedIndexChanged(object sender, EventArgs e) {
            listTopic.Items.Clear();
            string item = listHistory.SelectedItem.ToString();
            if (item != "") {
                var data = item.Split(':');
                long index = long.Parse(data[0]);
                using (var db = new DuoContext()) {
                    var hisDetail = db.HistoryDetails.AsNoTracking()
                        .Where(x => x.MyHistory.Id == index)
                        .Select(x => new { Id = x.TopicId, TopicTitle = x.MyTopic.Title }).ToList();
                    if (hisDetail.Count > 0) {
                        foreach (var detail in hisDetail) {
                            string dataHisDetail = detail.Id + ": " + detail.TopicTitle;
                            listTopic.Items.Add(dataHisDetail);
                        }
                    }
                }
            }
        }
    }
}
