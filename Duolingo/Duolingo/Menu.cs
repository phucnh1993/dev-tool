using Duolingo.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            using (var db = new DuoContext()) {
                data += "Number topic: " + db.Topics.Count(x => x.IsActivated) + "\r\n";
                data += "Number question: " + db.Questions.Count(x => x.IsActivated);
            }
            databaseInfo.Text = data;
        }
    }
}
