using DevTool.Domains;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DevTool.Tools.AppRunCommand {
    public partial class ApplicationManager : Form {
        private readonly ToolContext _db;

        public ApplicationManager() {
            InitializeComponent();
            _db = new ToolContext();
        }

        private void ApplicationManager_Load(object sender, EventArgs e) {
            using(var db = _db) {
                var datas = db.AppRuns.AsNoTracking().ToList();
                dataApplications.DataSource = datas;
                dataApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            this.Refresh();
        }

        private void btnRefesh_Click(object sender, EventArgs e) {
            using (var db = _db) {
                dataApplications.DataSource = null;
                var datas = db.AppRuns.AsNoTracking().ToList();
                dataApplications.DataSource = datas;
                dataApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            this.Refresh();
        }

        private void ApplicationManager_FormClosed(object sender, FormClosedEventArgs e) {
            _db.Dispose();
        }

        private void ApplicationManager_FormClosing(object sender, FormClosingEventArgs e) {
            _db.Dispose();
        }

        private void btnSaveChange_Click(object sender, EventArgs e) {
            string appName = applicationName.Text;
            string appType = applicationType.Text;
        }
    }
}
