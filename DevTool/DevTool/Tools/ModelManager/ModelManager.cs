using System;
using System.Windows.Forms;

namespace DevTool.Tools.ModelManager {
    public partial class ModelManager : Form {
        public ModelManager() {
            InitializeComponent();
        }

        private void dataTypeManagerToolStripMenuItem_Click(object sender, EventArgs e) {
            DataTypeManager dtm = new DataTypeManager();
            dtm.Show();
        }
    }
}
