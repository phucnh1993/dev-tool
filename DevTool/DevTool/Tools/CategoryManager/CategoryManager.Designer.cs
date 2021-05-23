
namespace DevTool.Tools.CategoryManager {
    partial class CategoryManager {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.boxCategoryParent = new System.Windows.Forms.ComboBox();
            this.datChildren = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCreatedDate = new System.Windows.Forms.TextBox();
            this.isActivated = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCategoryData = new System.Windows.Forms.TextBox();
            this.isParent = new System.Windows.Forms.CheckBox();
            this.txtNumberChildren = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datChildren)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category Parent";
            // 
            // boxCategoryParent
            // 
            this.boxCategoryParent.FormattingEnabled = true;
            this.boxCategoryParent.Location = new System.Drawing.Point(101, 6);
            this.boxCategoryParent.Name = "boxCategoryParent";
            this.boxCategoryParent.Size = new System.Drawing.Size(375, 21);
            this.boxCategoryParent.TabIndex = 1;
            // 
            // datChildren
            // 
            this.datChildren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datChildren.Location = new System.Drawing.Point(1, 33);
            this.datChildren.Name = "datChildren";
            this.datChildren.Size = new System.Drawing.Size(475, 607);
            this.datChildren.TabIndex = 2;
            this.datChildren.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datChildren_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(494, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.SystemColors.Highlight;
            this.txtId.ForeColor = System.Drawing.SystemColors.Window;
            this.txtId.Location = new System.Drawing.Point(518, 6);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(624, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Category Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(710, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(501, 20);
            this.txtName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(496, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Created Date";
            // 
            // txtCreatedDate
            // 
            this.txtCreatedDate.BackColor = System.Drawing.SystemColors.Highlight;
            this.txtCreatedDate.ForeColor = System.Drawing.SystemColors.Window;
            this.txtCreatedDate.Location = new System.Drawing.Point(572, 33);
            this.txtCreatedDate.Name = "txtCreatedDate";
            this.txtCreatedDate.ReadOnly = true;
            this.txtCreatedDate.Size = new System.Drawing.Size(132, 20);
            this.txtCreatedDate.TabIndex = 8;
            // 
            // isActivated
            // 
            this.isActivated.AutoSize = true;
            this.isActivated.Location = new System.Drawing.Point(710, 35);
            this.isActivated.Name = "isActivated";
            this.isActivated.Size = new System.Drawing.Size(82, 17);
            this.isActivated.TabIndex = 9;
            this.isActivated.Text = "Is Activated";
            this.isActivated.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Location = new System.Drawing.Point(497, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(714, 174);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(6, 19);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(702, 149);
            this.txtDescription.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCategoryData);
            this.groupBox2.Location = new System.Drawing.Point(499, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(714, 401);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data";
            // 
            // txtCategoryData
            // 
            this.txtCategoryData.Location = new System.Drawing.Point(6, 19);
            this.txtCategoryData.Multiline = true;
            this.txtCategoryData.Name = "txtCategoryData";
            this.txtCategoryData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCategoryData.Size = new System.Drawing.Size(702, 376);
            this.txtCategoryData.TabIndex = 0;
            // 
            // isParent
            // 
            this.isParent.AutoSize = true;
            this.isParent.Location = new System.Drawing.Point(798, 35);
            this.isParent.Name = "isParent";
            this.isParent.Size = new System.Drawing.Size(68, 17);
            this.isParent.TabIndex = 12;
            this.isParent.Text = "Is Parent";
            this.isParent.UseVisualStyleBackColor = true;
            // 
            // txtNumberChildren
            // 
            this.txtNumberChildren.BackColor = System.Drawing.SystemColors.Highlight;
            this.txtNumberChildren.ForeColor = System.Drawing.SystemColors.Window;
            this.txtNumberChildren.Location = new System.Drawing.Point(103, 646);
            this.txtNumberChildren.Name = "txtNumberChildren";
            this.txtNumberChildren.ReadOnly = true;
            this.txtNumberChildren.Size = new System.Drawing.Size(76, 20);
            this.txtNumberChildren.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 649);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Number Children";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(499, 646);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(580, 646);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(742, 646);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 17;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(661, 646);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 18;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // CategoryManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 676);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNumberChildren);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.isParent);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.isActivated);
            this.Controls.Add(this.txtCreatedDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datChildren);
            this.Controls.Add(this.boxCategoryParent);
            this.Controls.Add(this.label1);
            this.Name = "CategoryManager";
            this.Text = "Category Manager";
            this.Load += new System.EventHandler(this.CategoryManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datChildren)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox boxCategoryParent;
        private System.Windows.Forms.DataGridView datChildren;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCreatedDate;
        private System.Windows.Forms.CheckBox isActivated;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCategoryData;
        private System.Windows.Forms.CheckBox isParent;
        private System.Windows.Forms.TextBox txtNumberChildren;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnUp;
    }
}