
namespace Duolingo {
    partial class Menu {
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
            this.components = new System.ComponentModel.Container();
            this.databaseInfo = new System.Windows.Forms.TextBox();
            this.manageData = new System.Windows.Forms.Button();
            this.autoRun = new System.Windows.Forms.Button();
            this.refeshInfo = new System.Windows.Forms.Button();
            this.reloadAuto = new System.Windows.Forms.Timer(this.components);
            this.manageHistory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // databaseInfo
            // 
            this.databaseInfo.BackColor = System.Drawing.SystemColors.HotTrack;
            this.databaseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseInfo.ForeColor = System.Drawing.SystemColors.Window;
            this.databaseInfo.Location = new System.Drawing.Point(12, 12);
            this.databaseInfo.Multiline = true;
            this.databaseInfo.Name = "databaseInfo";
            this.databaseInfo.ReadOnly = true;
            this.databaseInfo.Size = new System.Drawing.Size(211, 171);
            this.databaseInfo.TabIndex = 0;
            // 
            // manageData
            // 
            this.manageData.Location = new System.Drawing.Point(229, 12);
            this.manageData.Name = "manageData";
            this.manageData.Size = new System.Drawing.Size(121, 23);
            this.manageData.TabIndex = 1;
            this.manageData.Text = "Manage Topic";
            this.manageData.UseVisualStyleBackColor = true;
            this.manageData.Click += new System.EventHandler(this.manageData_Click);
            // 
            // autoRun
            // 
            this.autoRun.Location = new System.Drawing.Point(229, 41);
            this.autoRun.Name = "autoRun";
            this.autoRun.Size = new System.Drawing.Size(121, 23);
            this.autoRun.TabIndex = 2;
            this.autoRun.Text = "Auto Run";
            this.autoRun.UseVisualStyleBackColor = true;
            this.autoRun.Click += new System.EventHandler(this.autoRun_Click);
            // 
            // refeshInfo
            // 
            this.refeshInfo.Location = new System.Drawing.Point(229, 70);
            this.refeshInfo.Name = "refeshInfo";
            this.refeshInfo.Size = new System.Drawing.Size(121, 23);
            this.refeshInfo.TabIndex = 3;
            this.refeshInfo.Text = "Refesh Info";
            this.refeshInfo.UseVisualStyleBackColor = true;
            this.refeshInfo.Click += new System.EventHandler(this.refeshInfo_Click);
            // 
            // reloadAuto
            // 
            this.reloadAuto.Enabled = true;
            this.reloadAuto.Interval = 5000;
            this.reloadAuto.Tick += new System.EventHandler(this.reloadAuto_Tick);
            // 
            // manageHistory
            // 
            this.manageHistory.Location = new System.Drawing.Point(229, 99);
            this.manageHistory.Name = "manageHistory";
            this.manageHistory.Size = new System.Drawing.Size(121, 23);
            this.manageHistory.TabIndex = 4;
            this.manageHistory.Text = "Manage History";
            this.manageHistory.UseVisualStyleBackColor = true;
            this.manageHistory.Click += new System.EventHandler(this.manageHistory_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 193);
            this.Controls.Add(this.manageHistory);
            this.Controls.Add(this.refeshInfo);
            this.Controls.Add(this.autoRun);
            this.Controls.Add(this.manageData);
            this.Controls.Add(this.databaseInfo);
            this.Name = "Menu";
            this.Text = "Menu Duolingo";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox databaseInfo;
        private System.Windows.Forms.Button manageData;
        private System.Windows.Forms.Button autoRun;
        private System.Windows.Forms.Button refeshInfo;
        private System.Windows.Forms.Timer reloadAuto;
        private System.Windows.Forms.Button manageHistory;
    }
}

