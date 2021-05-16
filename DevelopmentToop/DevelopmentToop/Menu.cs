using Portal.Database;
using Portal.Domain;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DevelopmentToop {
    public partial class Menu : Form {
        public Menu() {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e) {
            using (var db = new PortalContext()) {
                var tools = db.Tools.Where(x => x.IsActivated).OrderBy(x => x.Sort).ToList();
                boxApplication.DataSource = tools;
                boxApplication.DisplayMember = "Name";
            }
        }

        private void btnUse_Click(object sender, EventArgs e) {

        }

        private void boxApplication_SelectedIndexChanged(object sender, EventArgs e) {
            var tool = (Tool)boxApplication.SelectedItem;
            txtDescription.Text = "Tên công cụ: " + tool.Name + "\r\n";
            txtDescription.Text = "Ngày tạo: " + tool.CreatedDate + "\r\n";
            txtDescription.Text = "Mô tả: " + tool.Description;
        }
    }
}
