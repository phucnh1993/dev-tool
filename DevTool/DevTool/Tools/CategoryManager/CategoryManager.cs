using DevTool.Domains;
using DevTool.Domains.Entities;
using DevTool.Domains.Models;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevTool.Tools.CategoryManager {
    public partial class CategoryManager : Form {
        private Category category;
        public CategoryManager() {
            InitializeComponent();
        }

        private void LoadData() {
            using (var db = new CreatorContext()) {
                var cateParents = db.Categories.Where(x => x.GroupId == null).ToList();
                var cateParent = cateParents.Select(x => new ComboBoxModel() { Id = x.Id, Name = x.Name, Parent = 0, Sort = x.Sort }).ToList();
                cateParent.Add(new ComboBoxModel() { Id = 0, Name = "NULL", Parent = null, Sort = 0 });
                cateParent = cateParent.OrderBy(x => x.Sort).ToList();
                boxCategoryParent.DataSource = cateParent;
                boxCategoryParent.DisplayMember = "Name";
            }
            datChildren.DataSource = null;
            category = new Category();
            isActivated.Checked = true;
        }

        private void CategoryManager_Load(object sender, EventArgs e) {
            LoadData();
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
                LoadData();
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
                }
                LoadData();
            }
        }

        private void btnUp_Click(object sender, EventArgs e) {
            using (var db = new CreatorContext()) {

            }
        }

        private void btnReload_Click(object sender, EventArgs e) {
            LoadData();
        }

        private void datChildren_CellClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void boxCategoryParent_SelectedIndexChanged(object sender, EventArgs e) {
            var index = (ComboBoxModel) boxCategoryParent.SelectedItem;
            long? parentId = null;
            if (index.Id != 0) {
                parentId = index.Id;
            }
            using (var db = new CreatorContext()) {
                var cates = db.Categories.Where(x => x.IsActivated && x.GroupId == parentId)
                    .Select(x => new TableModel { Id = x.Id, Name = x.Name, CreateDate = x.CreatedDate })
                    .ToList();
                datChildren.DataSource = cates;
            }
        }
    }
}
