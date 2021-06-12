using DevTool.Domains;
using DevTool.Domains.Entities;
using DevTool.Domains.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DevTool.Tools.ModelManager {
    public partial class DataTypeManager : Form {
        public DataTypeManager() {
            InitializeComponent();
        }

        private void Reload() {
            tblDataTypes.DataSource = null;
            using (var db = new CreatorContext()) {
                var data = db.DataTypes.OrderBy(x => x.Sort)
                    .Select(x => new DataTypeDatasource {
                        Id = x.Id,
                        Name = x.Name,
                        Code = x.Code
                    }).ToList();
                tblDataTypes.DataSource = data;
            }
            this.Refresh();
        }

        private void DataTypeManager_Load(object sender, EventArgs e) {
            Reload();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(txtId.Text)) {
                long id = long.Parse(txtId.Text);
                using (var db = new CreatorContext()) {
                    var data = db.DataTypes.FirstOrDefault(x => x.Id == id);
                    data.Name = txtName.Text;
                    data.Code = txtCode.Text;
                    data.Description = txtDescription.Text;
                    int maxLength = -1;
                    int.TryParse(txtMaxLength.Text, out maxLength);
                    data.MaxLength = maxLength;
                    data.IsActivated = isActivated.Checked;
                    db.Update(data);
                }
            } else {
                if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtCode.Text)) {
                    int maxLength = -1;
                    int.TryParse(txtMaxLength.Text, out maxLength);
                    var data = new DataType() {
                        Name = txtName.Text,
                        Code = txtCode.Text,
                        Description = txtDescription.Text,
                        MultiName = "",
                        MultiNameMapType = "",
                        IsActivated = isActivated.Checked,
                        MaxLength = maxLength
                    };
                    using (var db = new CreatorContext()) {
                        var count = db.DataTypes.Count();
                        data.Sort = count + 1;
                        db.DataTypes.Add(data);
                        db.SaveChanges();
                    }
                } else {
                    MessageBox.Show("Data type name or code is empty", "Empty input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void tblDataTypes_CellClick(object sender, DataGridViewCellEventArgs e) {
            long id = 0;
            if (tblDataTypes.SelectedRows.Count > 0) {
                DataGridViewRow row = tblDataTypes.SelectedRows[0];
                id = long.Parse(row.Cells[0].Value.ToString());

            }
            if (tblDataTypes.SelectedCells.Count > 0) {
                var cell = tblDataTypes.SelectedCells[0];
                switch (cell.ColumnIndex) {
                    case 0:
                        id = long.Parse(cell.Value.ToString());
                        break;
                    default:
                        return;
                }
            }
            DataType data = null;
            using (var db = new CreatorContext()) {
                data = db.DataTypes.FirstOrDefault(x => x.Id == id);
            }
            txtId.Text = data.Id.ToString();
            txtName.Text = data.Name;
            txtCode.Text = data.Code;
            txtMaxLength.Text = data.MaxLength.ToString();
            txtDescription.Text = data.Description;
            isActivated.Checked = data.IsActivated;
            this.Refresh();
        }

        private void btnReload_Click(object sender, EventArgs e) {
            Reload();
        }
    }
}
