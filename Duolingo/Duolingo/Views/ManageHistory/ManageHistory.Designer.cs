
namespace Duolingo.Views.ManageHistory {
    partial class ManageHistory {
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
            this.listHistory = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listTopic = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.selectTopic = new System.Windows.Forms.ComboBox();
            this.addHistory = new System.Windows.Forms.Button();
            this.reload = new System.Windows.Forms.Button();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.totalHistory = new System.Windows.Forms.TextBox();
            this.export = new System.Windows.Forms.Button();
            this.import = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listHistory
            // 
            this.listHistory.FormattingEnabled = true;
            this.listHistory.Location = new System.Drawing.Point(12, 25);
            this.listHistory.Name = "listHistory";
            this.listHistory.Size = new System.Drawing.Size(176, 316);
            this.listHistory.TabIndex = 0;
            this.listHistory.SelectedIndexChanged += new System.EventHandler(this.listHistory_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "List History";
            // 
            // listTopic
            // 
            this.listTopic.FormattingEnabled = true;
            this.listTopic.Location = new System.Drawing.Point(194, 25);
            this.listTopic.Name = "listTopic";
            this.listTopic.Size = new System.Drawing.Size(157, 316);
            this.listTopic.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "List Topic of History";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Topic";
            // 
            // selectTopic
            // 
            this.selectTopic.FormattingEnabled = true;
            this.selectTopic.Location = new System.Drawing.Point(49, 347);
            this.selectTopic.Name = "selectTopic";
            this.selectTopic.Size = new System.Drawing.Size(139, 21);
            this.selectTopic.TabIndex = 5;
            // 
            // addHistory
            // 
            this.addHistory.Location = new System.Drawing.Point(276, 345);
            this.addHistory.Name = "addHistory";
            this.addHistory.Size = new System.Drawing.Size(75, 23);
            this.addHistory.TabIndex = 6;
            this.addHistory.Text = "Add History";
            this.addHistory.UseVisualStyleBackColor = true;
            this.addHistory.Click += new System.EventHandler(this.addHistory_Click);
            // 
            // reload
            // 
            this.reload.Location = new System.Drawing.Point(276, 426);
            this.reload.Name = "reload";
            this.reload.Size = new System.Drawing.Size(75, 23);
            this.reload.TabIndex = 7;
            this.reload.Text = "Reload";
            this.reload.UseVisualStyleBackColor = true;
            this.reload.Click += new System.EventHandler(this.reload_Click);
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(73, 374);
            this.startDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(278, 20);
            this.startDate.TabIndex = 8;
            this.startDate.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Start Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 403);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "End Date";
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(73, 400);
            this.endDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(278, 20);
            this.endDate.TabIndex = 10;
            this.endDate.Value = new System.DateTime(9970, 12, 31, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 431);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Total History";
            // 
            // totalHistory
            // 
            this.totalHistory.BackColor = System.Drawing.SystemColors.Highlight;
            this.totalHistory.ForeColor = System.Drawing.SystemColors.Window;
            this.totalHistory.Location = new System.Drawing.Point(81, 428);
            this.totalHistory.Name = "totalHistory";
            this.totalHistory.ReadOnly = true;
            this.totalHistory.Size = new System.Drawing.Size(108, 20);
            this.totalHistory.TabIndex = 13;
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(195, 426);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(75, 23);
            this.export.TabIndex = 14;
            this.export.Text = "Export";
            this.export.UseVisualStyleBackColor = true;
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(194, 345);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(75, 23);
            this.import.TabIndex = 15;
            this.import.Text = "Import";
            this.import.UseVisualStyleBackColor = true;
            // 
            // ManageHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 456);
            this.Controls.Add(this.import);
            this.Controls.Add(this.export);
            this.Controls.Add(this.totalHistory);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.reload);
            this.Controls.Add(this.addHistory);
            this.Controls.Add(this.selectTopic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listTopic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listHistory);
            this.Name = "ManageHistory";
            this.Text = "ManageHistory";
            this.Load += new System.EventHandler(this.ManageHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listHistory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listTopic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox selectTopic;
        private System.Windows.Forms.Button addHistory;
        private System.Windows.Forms.Button reload;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox totalHistory;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button import;
    }
}