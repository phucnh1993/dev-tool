using DevTool.Tools.CategoryManager;
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
    }
}
