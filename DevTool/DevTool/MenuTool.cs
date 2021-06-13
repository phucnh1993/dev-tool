using DevTool.Domains;
using DevTool.Tools.CategoryManager;
using DevTool.Tools.ModelManager;
using DevTool.Tools.PortManager;
using System;
using System.Windows.Forms;

namespace DevTool {
    public partial class MenuTool : Form {
        public MenuTool() {
            InitializeComponent();
        }

        private void btnPortManager_Click(object sender, EventArgs e) {
            PortManager pm = new PortManager();
            pm.Show();
        }

        private void btnCategoryManager_Click(object sender, EventArgs e) {
            CategoryManager cm = new CategoryManager();
            cm.Show();
        }

        private void MenuTool_Load(object sender, EventArgs e) {
            using (var db = new CreatorContext()) {
                if (!db.Database.Exists()) {
                    systemStatus.Text = "Database cannot connect!";
                } else {
                    systemStatus.Text = "System status is good!";
                }
            }
        }

        private void btnModelController_Click(object sender, EventArgs e) {
            ModelManager mm = new ModelManager();
            mm.Show();
        }
    }
}
