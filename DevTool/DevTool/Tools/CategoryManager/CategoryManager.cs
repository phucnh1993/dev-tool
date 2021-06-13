using DevTool.Domains;
using DevTool.Domains.Entities;
using DevTool.Domains.Models;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevTool.Tools.CategoryManager {
    public partial class CategoryManager : Form {
        public CategoryManager() {
            InitializeComponent();
        }

        private void SetSizeColumn() {
            DataGridViewColumn column_id = datChildren.Columns[0];
            column_id.Width = 80;
            DataGridViewColumn column_name = datChildren.Columns[1];
            column_name.Width = 250;
            DataGridViewColumn column_created = datChildren.Columns[2];
            column_created.Width = 115;
        }

        private void LoadData(long startId) {
            using (var db = new CreatorContext()) {
                var cateParent = db.Categories.Where(x => x.GroupId == null)
                    .Select(x => new ComboBoxModel() { Id = x.Id, Name = x.Name, Parent = 0, Sort = x.Sort }).ToList();
                cateParent.Add(new ComboBoxModel() { Id = 0, Name = "NULL", Parent = null, Sort = 0 });
                cateParent = cateParent.OrderBy(x => x.Sort).ToList();
                boxCategoryParent.DataSource = cateParent;
                boxCategoryParent.DisplayMember = "Name";
                if (startId == 0) {
                    var cates = db.Categories.Where(x => x.IsActivated && x.GroupId == null)
                        .OrderBy(x => x.Sort)
                        .Select(x => new TableModel { Id = x.Id, Name = x.Name, CreateDate = x.CreatedDate })
                        .ToList();
                    datChildren.DataSource = cates;
                } else {
                    datChildren.DataSource = null;
                }
            }
            SetSizeColumn();
            isActivated.Checked = true;
        }

        private void CategoryManager_Load(object sender, EventArgs e) {
            LoadData(0);
        }

        private void btnSave_Click(object sender, EventArgs e) {
            var question = MessageBox.Show("Do you want save change data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (question == DialogResult.Yes) {
                Category cate = new Category();
                var categoryParent = (ComboBoxModel) boxCategoryParent.SelectedItem;
                if (categoryParent.Id == 0) {
                    cate.GroupId = null;
                } else {
                    cate.GroupId = categoryParent.Id;
                }
                cate.Name = txtName.Text;
                cate.Description = txtDescription.Text;
                cate.IsActivated = isActivated.Checked;
                cate.CategoryData = Encoding.UTF8.GetBytes(txtCategoryData.Text);
                if (string.IsNullOrEmpty(txtId.Text)) {
                    cate.CreatedDate = DateTime.Now;
                    using (var db = new CreatorContext()) {
                        var count = db.Categories.Count();
                        cate.Sort = count + 1;
                        db.Categories.Add(cate);
                        db.SaveChanges();
                    }
                } else {
                    using (var db = new CreatorContext()) {
                        db.Update(cate);
                    }
                }
                LoadData(cate.GroupId.Value);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            var question = MessageBox.Show("Do you want delete data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (question == DialogResult.Yes && !string.IsNullOrEmpty(txtId.Text)) {
                long id = long.Parse(txtId.Text);
                using (var db = new CreatorContext()) {
                    var cate = db.Categories.Where(x => x.Id == id).FirstOrDefault();
                    db.Categories.Remove(cate);
                    db.SaveChanges();
                    LoadData(cate.GroupId.Value);
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(txtId.Text)) {
                long id = long.Parse(txtId.Text);
                using (var db = new CreatorContext()) {
                    var cate = db.Categories.FirstOrDefault(x => x.Id == id);
                    var cate_2 = db.Categories.FirstOrDefault(x => x.GroupId == cate.GroupId && x.Sort < cate.Sort);
                    if (cate_2 != null) {
                        int sort = cate.Sort;
                        cate.Sort = cate_2.Sort;
                        cate_2.Sort = sort;
                        db.Update(cate);
                        db.Update(cate_2);
                        LoadData(cate.GroupId.HasValue ? cate.GroupId.Value : 0);
                    }
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e) {
            LoadData(0);
        }

        private void datChildren_CellClick(object sender, DataGridViewCellEventArgs e) {
            long id = 0;
            if (datChildren.SelectedRows.Count > 0) {
                DataGridViewRow row = datChildren.SelectedRows[0];
                id = long.Parse(row.Cells[0].Value.ToString());
                
            }
            if (datChildren.SelectedCells.Count > 0) {
                var cell = datChildren.SelectedCells[0];
                switch (cell.ColumnIndex) {
                    case 0:
                        id = long.Parse(cell.Value.ToString());
                        break;
                    default:
                        return;
                }
            }
            Category cate = null;
            using (var db = new CreatorContext()) {
                cate = db.Categories.FirstOrDefault(x => x.Id == id);
            }
            txtId.Text = cate.Id.ToString();
            txtName.Text = cate.Name;
            txtCreatedDate.Text = cate.CreatedDate.ToString();
            txtDescription.Text = cate.Description;
            txtCategoryData.Text = Encoding.UTF8.GetString(cate.CategoryData);
            isActivated.Checked = cate.IsActivated;
            isParent.Checked = !cate.GroupId.HasValue;
            this.Refresh();
        }

        private void boxCategoryParent_SelectedIndexChanged(object sender, EventArgs e) {
            var index = (ComboBoxModel) boxCategoryParent.SelectedItem;
            long? parentId = null;
            if (index.Id != 0) {
                parentId = index.Id;
            }
            using (var db = new CreatorContext()) {
                var cates = db.Categories.Where(x => x.IsActivated && x.GroupId == parentId)
                    .OrderBy(x => x.Sort)
                    .Select(x => new TableModel { Id = x.Id, Name = x.Name, CreateDate = x.CreatedDate })
                    .ToList();
                datChildren.DataSource = cates;
                txtNumberChildren.Text = cates.Count.ToString();
                SetSizeColumn();
            }
        }
    }
}
