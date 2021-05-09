using Duolingo.Entities;
using System;
using System.Collections.Generic;
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

        }

        private void reload_Click(object sender, EventArgs e) {
            var start = startDate.Value;
            var end = endDate.Value;
            Reload(start, end);
        }
    }
}
