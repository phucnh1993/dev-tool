using Duolingo.Entities;
using Duolingo.Views.ManageHistory;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Duolingo {
    public partial class Menu : Form {
        public Menu() {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e) {
            ReloadData();
        }

        private void refeshInfo_Click(object sender, EventArgs e) {
            ReloadData();
        }

        private void autoRun_Click(object sender, EventArgs e) {

        }

        private void manageData_Click(object sender, EventArgs e) {

        }

        private void reloadAuto_Tick(object sender, EventArgs e) {
            ReloadData();
        }

        private void ReloadData() {
            string data = "";
            var startDate = DateTime.Now.Date;
            var endDate = startDate.AddDays(1);
            using (var db = new DuoContext()) {
                data += "Number topic: " + db.Topics.Count(x => x.IsActivated) + "\r\n";
                data += "Number question: " + db.Questions.Count(x => x.IsActivated) + "\r\n";
                data += "Number topic test today: " + db.HistoryDetails.Count(x => x.MyHistory.CreatedDate >= startDate && x.MyHistory.CreatedDate < endDate);
            }
            databaseInfo.Text = data;
        }

        private void manageHistory_Click(object sender, EventArgs e) {
            ManageHistory mh = new ManageHistory();
            mh.Show();
        }
    }
}
