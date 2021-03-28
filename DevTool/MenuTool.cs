using DevTool.Tools.LanguageCodeManager;
using DevTool.Tools.PortManager;
using System;
using System.IO;
using System.Windows.Forms;

namespace DevTool {
    public partial class MenuTool : Form {
        public MenuTool() {
            InitializeComponent();
            CreateDataDirectory();
        }

        private void btnPortManager_Click(object sender, EventArgs e) {
            PortManager pm = new PortManager();
            pm.Show();
        }

        private void btnLanguageManager_Click(object sender, EventArgs e) {
            LanguageCodes lc = new LanguageCodes();
            lc.Show();
        }

        private void CreateDataDirectory() {
            DirectoryInfo di = new DirectoryInfo("data");
            if (!di.Exists) {
                di.Create();
            }
        }
    }
}
