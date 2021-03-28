
namespace DevTool.Tools.LanguageCodeManager {
    partial class LanguageCodes {
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
            this.languageListData = new System.Windows.Forms.DataGridView();
            this.lblLanguageId = new System.Windows.Forms.Label();
            this.languageId = new System.Windows.Forms.TextBox();
            this.languageName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.languageVersion = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.createdOn = new System.Windows.Forms.TextBox();
            this.lblCreatedOn = new System.Windows.Forms.Label();
            this.chkIsActivated = new System.Windows.Forms.CheckBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.languageDescription = new System.Windows.Forms.TextBox();
            this.btnRefesh = new System.Windows.Forms.Button();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.pageList = new System.Windows.Forms.ComboBox();
            this.lblNumberRow = new System.Windows.Forms.Label();
            this.limitList = new System.Windows.Forms.ComboBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.languageListData)).BeginInit();
            this.SuspendLayout();
            // 
            // languageListData
            // 
            this.languageListData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.languageListData.Location = new System.Drawing.Point(0, 0);
            this.languageListData.Name = "languageListData";
            this.languageListData.Size = new System.Drawing.Size(1023, 521);
            this.languageListData.TabIndex = 0;
            this.languageListData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.languageListData_CellClick);
            this.languageListData.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.languageListData_ColumnHeaderMouseClick);
            // 
            // lblLanguageId
            // 
            this.lblLanguageId.AutoSize = true;
            this.lblLanguageId.Location = new System.Drawing.Point(12, 533);
            this.lblLanguageId.Name = "lblLanguageId";
            this.lblLanguageId.Size = new System.Drawing.Size(18, 13);
            this.lblLanguageId.TabIndex = 1;
            this.lblLanguageId.Text = "ID";
            // 
            // languageId
            // 
            this.languageId.Location = new System.Drawing.Point(53, 530);
            this.languageId.MaxLength = 30;
            this.languageId.Name = "languageId";
            this.languageId.ReadOnly = true;
            this.languageId.Size = new System.Drawing.Size(100, 20);
            this.languageId.TabIndex = 2;
            this.languageId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.languageId_KeyPress);
            // 
            // languageName
            // 
            this.languageName.Location = new System.Drawing.Point(53, 557);
            this.languageName.MaxLength = 100;
            this.languageName.Name = "languageName";
            this.languageName.Size = new System.Drawing.Size(234, 20);
            this.languageName.TabIndex = 4;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 560);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            // 
            // languageVersion
            // 
            this.languageVersion.Location = new System.Drawing.Point(341, 558);
            this.languageVersion.MaxLength = 20;
            this.languageVersion.Name = "languageVersion";
            this.languageVersion.Size = new System.Drawing.Size(110, 20);
            this.languageVersion.TabIndex = 6;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(293, 560);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 5;
            this.lblVersion.Text = "Version";
            // 
            // createdOn
            // 
            this.createdOn.Location = new System.Drawing.Point(224, 530);
            this.createdOn.MaxLength = 30;
            this.createdOn.Name = "createdOn";
            this.createdOn.ReadOnly = true;
            this.createdOn.Size = new System.Drawing.Size(141, 20);
            this.createdOn.TabIndex = 8;
            // 
            // lblCreatedOn
            // 
            this.lblCreatedOn.AutoSize = true;
            this.lblCreatedOn.Location = new System.Drawing.Point(159, 533);
            this.lblCreatedOn.Name = "lblCreatedOn";
            this.lblCreatedOn.Size = new System.Drawing.Size(59, 13);
            this.lblCreatedOn.TabIndex = 7;
            this.lblCreatedOn.Text = "Created on";
            // 
            // chkIsActivated
            // 
            this.chkIsActivated.AutoSize = true;
            this.chkIsActivated.Location = new System.Drawing.Point(371, 531);
            this.chkIsActivated.Name = "chkIsActivated";
            this.chkIsActivated.Size = new System.Drawing.Size(82, 17);
            this.chkIsActivated.TabIndex = 9;
            this.chkIsActivated.Text = "Is Activated";
            this.chkIsActivated.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 581);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Description";
            // 
            // languageDescription
            // 
            this.languageDescription.Location = new System.Drawing.Point(12, 604);
            this.languageDescription.MaxLength = 500;
            this.languageDescription.Multiline = true;
            this.languageDescription.Name = "languageDescription";
            this.languageDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.languageDescription.Size = new System.Drawing.Size(824, 185);
            this.languageDescription.TabIndex = 11;
            // 
            // btnRefesh
            // 
            this.btnRefesh.BackColor = System.Drawing.Color.Lime;
            this.btnRefesh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnRefesh.Location = new System.Drawing.Point(680, 527);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(75, 23);
            this.btnRefesh.TabIndex = 12;
            this.btnRefesh.Text = "Refesh";
            this.btnRefesh.UseVisualStyleBackColor = false;
            this.btnRefesh.Click += new System.EventHandler(this.btnRefesh_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.BackColor = System.Drawing.Color.Blue;
            this.btnPreviousPage.ForeColor = System.Drawing.Color.White;
            this.btnPreviousPage.Location = new System.Drawing.Point(761, 527);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(75, 23);
            this.btnPreviousPage.TabIndex = 13;
            this.btnPreviousPage.Text = "< Previous";
            this.btnPreviousPage.UseVisualStyleBackColor = false;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.BackColor = System.Drawing.Color.Blue;
            this.btnNextPage.ForeColor = System.Drawing.Color.White;
            this.btnNextPage.Location = new System.Drawing.Point(936, 527);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(75, 23);
            this.btnNextPage.TabIndex = 14;
            this.btnNextPage.Text = "Next >";
            this.btnNextPage.UseVisualStyleBackColor = false;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // pageList
            // 
            this.pageList.FormattingEnabled = true;
            this.pageList.Location = new System.Drawing.Point(842, 529);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(88, 21);
            this.pageList.TabIndex = 15;
            // 
            // lblNumberRow
            // 
            this.lblNumberRow.AutoSize = true;
            this.lblNumberRow.Location = new System.Drawing.Point(478, 532);
            this.lblNumberRow.Name = "lblNumberRow";
            this.lblNumberRow.Size = new System.Drawing.Size(69, 13);
            this.lblNumberRow.TabIndex = 16;
            this.lblNumberRow.Text = "Number Row";
            // 
            // limitList
            // 
            this.limitList.FormattingEnabled = true;
            this.limitList.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100"});
            this.limitList.Location = new System.Drawing.Point(553, 529);
            this.limitList.Name = "limitList";
            this.limitList.Size = new System.Drawing.Size(121, 21);
            this.limitList.TabIndex = 17;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Green;
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(457, 556);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(108, 23);
            this.btnCreate.TabIndex = 18;
            this.btnCreate.Text = "Create / Update";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(571, 556);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 19;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // LanguageCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 801);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.limitList);
            this.Controls.Add(this.lblNumberRow);
            this.Controls.Add(this.pageList);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.btnRefesh);
            this.Controls.Add(this.languageDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.chkIsActivated);
            this.Controls.Add(this.createdOn);
            this.Controls.Add(this.lblCreatedOn);
            this.Controls.Add(this.languageVersion);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.languageName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.languageId);
            this.Controls.Add(this.lblLanguageId);
            this.Controls.Add(this.languageListData);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "LanguageCodes";
            this.Text = "Language Codes";
            this.Load += new System.EventHandler(this.LanguageCodes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.languageListData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView languageListData;
        private System.Windows.Forms.Label lblLanguageId;
        private System.Windows.Forms.TextBox languageId;
        private System.Windows.Forms.TextBox languageName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox languageVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox createdOn;
        private System.Windows.Forms.Label lblCreatedOn;
        private System.Windows.Forms.CheckBox chkIsActivated;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox languageDescription;
        private System.Windows.Forms.Button btnRefesh;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.ComboBox pageList;
        private System.Windows.Forms.Label lblNumberRow;
        private System.Windows.Forms.ComboBox limitList;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnRemove;
    }
}