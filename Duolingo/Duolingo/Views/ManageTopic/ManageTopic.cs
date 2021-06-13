using Duolingo.Entities;
using Duolingo.Services;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Duolingo.Views.ManageTopic {
    public partial class ManageTopic : Form {
        private Topic _topic;

        public ManageTopic() {
            InitializeComponent();
        }

        private void LoadData() {
            using (var db = new DuoContext()) {
                var topics = db.Topics.Where(x => !x.IsDeleted)
                    .OrderBy(x => x.Sort)
                    .Select(x => new { Id = x.Id, Title = x.Title })
                    .ToList();
                var count = topics.Count;
                totalTopic.Text = count.ToString();
                listTopic.Items.Clear();
                foreach (var item in topics) {
                    string data = item.Id + ": " + item.Title;
                    listTopic.Items.Add(data);
                }
            }
            _topic = null;
            topicTitle.Text = "";
            isHide.Checked = false;
            this.Refresh();
        }

        private void ManageTopic_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void saveChangeTopic_Click(object sender, EventArgs e) {
            if (_topic == null && !string.IsNullOrWhiteSpace(topicTitle.Text)) {
                var hashData = HashService.ComputeSha256Hash(topicTitle.Text);
                using (var db = new DuoContext()) {
                    if (db.Topics.AsNoTracking().Any(x => !x.IsDeleted && x.HashCompare.Equals(hashData))) {
                        MessageBox.Show("Tiêu đề của chủ đề đã tồn tại trong Database", "Cảnh báo trùng lập dữ liệu"
                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    var count = db.Topics.AsNoTracking().Count();
                    var topic = new Topic() {
                        Title = topicTitle.Text,
                        HashCompare = hashData,
                        IsDeleted = false,
                        IsHide = isHide.Checked,
                        Sort = count + 1
                    };
                    db.Topics.Add(topic);
                    db.SaveChanges();
                }
                LoadData();
                return;
            }
            if (_topic != null && !string.IsNullOrWhiteSpace(topicTitle.Text)) {
                using (var db = new DuoContext()) {
                    _topic.Title = topicTitle.Text;
                    _topic.HashCompare = HashService.ComputeSha256Hash(topicTitle.Text);
                    _topic.IsHide = isHide.Checked;
                    var chk = db.Update<Topic>(_topic);
                }
                LoadData();
                return;
            }
            MessageBox.Show("Vui lòng chọn một chủ đề hay nhập thông tin chủ đề", "Dữ liệu chưa có"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void deleteTopic_Click(object sender, EventArgs e) {
            if (_topic != null && !string.IsNullOrWhiteSpace(topicTitle.Text)) {
                using (var db = new DuoContext()) {
                    _topic.IsDeleted = true;
                    var chk = db.Update<Topic>(_topic);
                }
                LoadData();
                return;
            }
            MessageBox.Show("Vui lòng chọn một chủ đề hay nhập thông tin chủ đề", "Dữ liệu chưa được chọn"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void upTopic_Click(object sender, EventArgs e) {
            if (_topic != null && !string.IsNullOrWhiteSpace(topicTitle.Text)) {
                int sort = _topic.Sort;
                using (var db = new DuoContext()) {
                    var downTopic = db.Topics.FirstOrDefault(x => !x.IsDeleted && x.Sort < sort);
                    if (downTopic == null) {
                        MessageBox.Show("Không thể đưa chủ đề lên trên vì nó đã ở trên cùng", "Dữ liệu không thể thay đổi"
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    _topic.Sort = downTopic.Sort;
                    downTopic.Sort = sort;
                    db.Update<Topic>(_topic);
                    db.Update<Topic>(downTopic);
                }
                LoadData();
                return;
            }
            MessageBox.Show("Vui lòng chọn một chủ đề hay nhập thông tin chủ đề", "Dữ liệu chưa được chọn"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void downTopic_Click(object sender, EventArgs e) {
            if (_topic != null && !string.IsNullOrWhiteSpace(topicTitle.Text)) {
                int sort = _topic.Sort;
                using (var db = new DuoContext()) {
                    var upTopic = db.Topics.FirstOrDefault(x => !x.IsDeleted && x.Sort > sort);
                    if (upTopic == null) {
                        MessageBox.Show("Không thể đưa chủ đề xuống dưới vì nó đã ở dưới cùng", "Dữ liệu không thể thay đổi"
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    _topic.Sort = upTopic.Sort;
                    upTopic.Sort = sort;
                    db.Update<Topic>(_topic);
                    db.Update<Topic>(upTopic);
                }
                LoadData();
                return;
            }
            MessageBox.Show("Vui lòng chọn một chủ đề hay nhập thông tin chủ đề", "Dữ liệu chưa được chọn"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void refeshAll_Click(object sender, EventArgs e) {
            LoadData();
        }

        private void saveChangeQuestion_Click(object sender, EventArgs e) {

        }

        private void deleteQuestion_Click(object sender, EventArgs e) {

        }

        private void importFile_Click(object sender, EventArgs e) {

        }

        private void exportFile_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Topic File|*.tpc";
            saveFileDialog.Title = "Save an Image File";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "") {
                var fs = (FileStream) saveFileDialog.OpenFile();
                
                fs.Close();
            } else {
                MessageBox.Show("Tên file chưa được nhập","File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listTopic_SelectedIndexChanged(object sender, EventArgs e) {
            var value = (string) listTopic.SelectedItem;
            if (!string.IsNullOrEmpty(value)) {
                var id = value.Split(':')[0];
                using (var db = new DuoContext()) {
                    var idCompare = long.Parse(id);
                    _topic = db.Topics.AsNoTracking().FirstOrDefault(x => x.Id == idCompare);
                    topicTitle.Text = _topic.Title;
                    numberQuestion.Text = _topic.Questions.Count().ToString();
                    isHide.Checked = _topic.IsHide;
                }
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {

        }
    }
}
