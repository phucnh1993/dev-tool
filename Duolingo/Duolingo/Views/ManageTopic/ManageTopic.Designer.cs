
namespace Duolingo.Views.ManageTopic {
    partial class ManageTopic {
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
            this.listTopic = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.topicTitle = new System.Windows.Forms.TextBox();
            this.numberQuestion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.isHide = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.questionEnglish = new System.Windows.Forms.TextBox();
            this.questionVietnamese = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.isActivated = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.totalTopic = new System.Windows.Forms.TextBox();
            this.saveChangeTopic = new System.Windows.Forms.Button();
            this.deleteTopic = new System.Windows.Forms.Button();
            this.upTopic = new System.Windows.Forms.Button();
            this.downTopic = new System.Windows.Forms.Button();
            this.refeshAll = new System.Windows.Forms.Button();
            this.saveChangeQuestion = new System.Windows.Forms.Button();
            this.deleteQuestion = new System.Windows.Forms.Button();
            this.importFile = new System.Windows.Forms.Button();
            this.exportFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách chủ đề";
            // 
            // listTopic
            // 
            this.listTopic.FormattingEnabled = true;
            this.listTopic.Location = new System.Drawing.Point(12, 25);
            this.listTopic.Name = "listTopic";
            this.listTopic.Size = new System.Drawing.Size(163, 680);
            this.listTopic.TabIndex = 1;
            this.listTopic.SelectedIndexChanged += new System.EventHandler(this.listTopic_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chủ đề";
            // 
            // topicTitle
            // 
            this.topicTitle.Location = new System.Drawing.Point(241, 6);
            this.topicTitle.Name = "topicTitle";
            this.topicTitle.Size = new System.Drawing.Size(186, 20);
            this.topicTitle.TabIndex = 3;
            // 
            // numberQuestion
            // 
            this.numberQuestion.BackColor = System.Drawing.SystemColors.HotTrack;
            this.numberQuestion.ForeColor = System.Drawing.SystemColors.Window;
            this.numberQuestion.Location = new System.Drawing.Point(526, 6);
            this.numberQuestion.Name = "numberQuestion";
            this.numberQuestion.ReadOnly = true;
            this.numberQuestion.Size = new System.Drawing.Size(83, 20);
            this.numberQuestion.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số lượng câu hỏi";
            // 
            // isHide
            // 
            this.isHide.AutoSize = true;
            this.isHide.Location = new System.Drawing.Point(615, 8);
            this.isHide.Name = "isHide";
            this.isHide.Size = new System.Drawing.Size(106, 17);
            this.isHide.TabIndex = 6;
            this.isHide.Text = "Ẩn khỏi lựa chọn";
            this.isHide.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(181, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1073, 623);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách câu hỏi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1061, 598);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 668);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nội dung tiếng Anh";
            // 
            // questionEnglish
            // 
            this.questionEnglish.Location = new System.Drawing.Point(285, 665);
            this.questionEnglish.Name = "questionEnglish";
            this.questionEnglish.Size = new System.Drawing.Size(969, 20);
            this.questionEnglish.TabIndex = 9;
            // 
            // questionVietnamese
            // 
            this.questionVietnamese.Location = new System.Drawing.Point(285, 691);
            this.questionVietnamese.Name = "questionVietnamese";
            this.questionVietnamese.Size = new System.Drawing.Size(969, 20);
            this.questionVietnamese.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 694);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nội dung tiếng Việt";
            // 
            // isActivated
            // 
            this.isActivated.AutoSize = true;
            this.isActivated.Location = new System.Drawing.Point(181, 720);
            this.isActivated.Name = "isActivated";
            this.isActivated.Size = new System.Drawing.Size(87, 17);
            this.isActivated.TabIndex = 12;
            this.isActivated.Text = "Ẩn khỏi gợi ý";
            this.isActivated.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 721);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tổng";
            // 
            // totalTopic
            // 
            this.totalTopic.BackColor = System.Drawing.SystemColors.HotTrack;
            this.totalTopic.ForeColor = System.Drawing.SystemColors.Window;
            this.totalTopic.Location = new System.Drawing.Point(51, 718);
            this.totalTopic.Name = "totalTopic";
            this.totalTopic.ReadOnly = true;
            this.totalTopic.Size = new System.Drawing.Size(124, 20);
            this.totalTopic.TabIndex = 14;
            // 
            // saveChangeTopic
            // 
            this.saveChangeTopic.Location = new System.Drawing.Point(727, 4);
            this.saveChangeTopic.Name = "saveChangeTopic";
            this.saveChangeTopic.Size = new System.Drawing.Size(123, 23);
            this.saveChangeTopic.TabIndex = 15;
            this.saveChangeTopic.Text = "Lưu thay đổi chủ đề";
            this.saveChangeTopic.UseVisualStyleBackColor = true;
            this.saveChangeTopic.Click += new System.EventHandler(this.saveChangeTopic_Click);
            // 
            // deleteTopic
            // 
            this.deleteTopic.Location = new System.Drawing.Point(856, 4);
            this.deleteTopic.Name = "deleteTopic";
            this.deleteTopic.Size = new System.Drawing.Size(93, 23);
            this.deleteTopic.TabIndex = 16;
            this.deleteTopic.Text = "Xóa chủ đề";
            this.deleteTopic.UseVisualStyleBackColor = true;
            this.deleteTopic.Click += new System.EventHandler(this.deleteTopic_Click);
            // 
            // upTopic
            // 
            this.upTopic.Location = new System.Drawing.Point(955, 4);
            this.upTopic.Name = "upTopic";
            this.upTopic.Size = new System.Drawing.Size(75, 23);
            this.upTopic.TabIndex = 17;
            this.upTopic.Text = "Đưa lên đầu";
            this.upTopic.UseVisualStyleBackColor = true;
            this.upTopic.Click += new System.EventHandler(this.upTopic_Click);
            // 
            // downTopic
            // 
            this.downTopic.Location = new System.Drawing.Point(1036, 4);
            this.downTopic.Name = "downTopic";
            this.downTopic.Size = new System.Drawing.Size(98, 23);
            this.downTopic.TabIndex = 18;
            this.downTopic.Text = "Đưa xuống dưới";
            this.downTopic.UseVisualStyleBackColor = true;
            this.downTopic.Click += new System.EventHandler(this.downTopic_Click);
            // 
            // refeshAll
            // 
            this.refeshAll.Location = new System.Drawing.Point(1140, 4);
            this.refeshAll.Name = "refeshAll";
            this.refeshAll.Size = new System.Drawing.Size(108, 23);
            this.refeshAll.TabIndex = 19;
            this.refeshAll.Text = "Làm mới dữ liệu";
            this.refeshAll.UseVisualStyleBackColor = true;
            this.refeshAll.Click += new System.EventHandler(this.refeshAll_Click);
            // 
            // saveChangeQuestion
            // 
            this.saveChangeQuestion.Location = new System.Drawing.Point(285, 716);
            this.saveChangeQuestion.Name = "saveChangeQuestion";
            this.saveChangeQuestion.Size = new System.Drawing.Size(133, 23);
            this.saveChangeQuestion.TabIndex = 20;
            this.saveChangeQuestion.Text = "Lưu thay đổi câu hỏi";
            this.saveChangeQuestion.UseVisualStyleBackColor = true;
            this.saveChangeQuestion.Click += new System.EventHandler(this.saveChangeQuestion_Click);
            // 
            // deleteQuestion
            // 
            this.deleteQuestion.Location = new System.Drawing.Point(424, 716);
            this.deleteQuestion.Name = "deleteQuestion";
            this.deleteQuestion.Size = new System.Drawing.Size(75, 23);
            this.deleteQuestion.TabIndex = 21;
            this.deleteQuestion.Text = "Xóa câu hỏi";
            this.deleteQuestion.UseVisualStyleBackColor = true;
            this.deleteQuestion.Click += new System.EventHandler(this.deleteQuestion_Click);
            // 
            // importFile
            // 
            this.importFile.Location = new System.Drawing.Point(505, 716);
            this.importFile.Name = "importFile";
            this.importFile.Size = new System.Drawing.Size(95, 23);
            this.importFile.TabIndex = 22;
            this.importFile.Text = "Nhập bằng file";
            this.importFile.UseVisualStyleBackColor = true;
            this.importFile.Click += new System.EventHandler(this.importFile_Click);
            // 
            // exportFile
            // 
            this.exportFile.Location = new System.Drawing.Point(606, 716);
            this.exportFile.Name = "exportFile";
            this.exportFile.Size = new System.Drawing.Size(78, 23);
            this.exportFile.TabIndex = 23;
            this.exportFile.Text = "Xuất ra file";
            this.exportFile.UseVisualStyleBackColor = true;
            this.exportFile.Click += new System.EventHandler(this.exportFile_Click);
            // 
            // ManageTopic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 748);
            this.Controls.Add(this.exportFile);
            this.Controls.Add(this.importFile);
            this.Controls.Add(this.deleteQuestion);
            this.Controls.Add(this.saveChangeQuestion);
            this.Controls.Add(this.refeshAll);
            this.Controls.Add(this.downTopic);
            this.Controls.Add(this.upTopic);
            this.Controls.Add(this.deleteTopic);
            this.Controls.Add(this.saveChangeTopic);
            this.Controls.Add(this.totalTopic);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.isActivated);
            this.Controls.Add(this.questionVietnamese);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.questionEnglish);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.isHide);
            this.Controls.Add(this.numberQuestion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.topicTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listTopic);
            this.Controls.Add(this.label1);
            this.Name = "ManageTopic";
            this.Text = "Quản lý chủ đề";
            this.Load += new System.EventHandler(this.ManageTopic_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listTopic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox topicTitle;
        private System.Windows.Forms.TextBox numberQuestion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox isHide;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox questionEnglish;
        private System.Windows.Forms.TextBox questionVietnamese;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox isActivated;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox totalTopic;
        private System.Windows.Forms.Button saveChangeTopic;
        private System.Windows.Forms.Button deleteTopic;
        private System.Windows.Forms.Button upTopic;
        private System.Windows.Forms.Button downTopic;
        private System.Windows.Forms.Button refeshAll;
        private System.Windows.Forms.Button saveChangeQuestion;
        private System.Windows.Forms.Button deleteQuestion;
        private System.Windows.Forms.Button importFile;
        private System.Windows.Forms.Button exportFile;
    }
}