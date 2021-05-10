using Duolingo.Entities;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Duolingo.Views.ManageTopic {
    public partial class ManageTopic : Form {
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
                foreach(var item in topics) {
                    string data = item.Id + ": " + item.Title;
                    listTopic.Items.Add(data);
                }
            }
        }

        private void ManageTopic_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void saveChangeTopic_Click(object sender, EventArgs e) {

        }

        private void deleteTopic_Click(object sender, EventArgs e) {

        }

        private void upTopic_Click(object sender, EventArgs e) {

        }

        private void downTopic_Click(object sender, EventArgs e) {

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

        }

        private void listTopic_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {

        }
    }
}
