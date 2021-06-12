
namespace DevTool {
    partial class MenuTool {
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
            this.btnPortManager = new System.Windows.Forms.Button();
            this.btnCategoryManager = new System.Windows.Forms.Button();
            this.systemStatus = new System.Windows.Forms.TextBox();
            this.btnModelController = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPortManager
            // 
            this.btnPortManager.Location = new System.Drawing.Point(299, 12);
            this.btnPortManager.Name = "btnPortManager";
            this.btnPortManager.Size = new System.Drawing.Size(126, 23);
            this.btnPortManager.TabIndex = 0;
            this.btnPortManager.Text = "Port Manager";
            this.btnPortManager.UseVisualStyleBackColor = true;
            this.btnPortManager.Click += new System.EventHandler(this.btnPortManager_Click);
            // 
            // btnCategoryManager
            // 
            this.btnCategoryManager.Location = new System.Drawing.Point(299, 41);
            this.btnCategoryManager.Name = "btnCategoryManager";
            this.btnCategoryManager.Size = new System.Drawing.Size(126, 23);
            this.btnCategoryManager.TabIndex = 1;
            this.btnCategoryManager.Text = "Category Manager";
            this.btnCategoryManager.UseVisualStyleBackColor = true;
            this.btnCategoryManager.Click += new System.EventHandler(this.btnCategoryManager_Click);
            // 
            // systemStatus
            // 
            this.systemStatus.BackColor = System.Drawing.SystemColors.HotTrack;
            this.systemStatus.ForeColor = System.Drawing.SystemColors.Window;
            this.systemStatus.Location = new System.Drawing.Point(12, 12);
            this.systemStatus.Multiline = true;
            this.systemStatus.Name = "systemStatus";
            this.systemStatus.ReadOnly = true;
            this.systemStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.systemStatus.Size = new System.Drawing.Size(281, 230);
            this.systemStatus.TabIndex = 2;
            // 
            // btnModelController
            // 
            this.btnModelController.Location = new System.Drawing.Point(299, 70);
            this.btnModelController.Name = "btnModelController";
            this.btnModelController.Size = new System.Drawing.Size(126, 23);
            this.btnModelController.TabIndex = 3;
            this.btnModelController.Text = "Model Manager";
            this.btnModelController.UseVisualStyleBackColor = true;
            this.btnModelController.Click += new System.EventHandler(this.btnModelController_Click);
            // 
            // MenuTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 254);
            this.Controls.Add(this.btnModelController);
            this.Controls.Add(this.systemStatus);
            this.Controls.Add(this.btnCategoryManager);
            this.Controls.Add(this.btnPortManager);
            this.Name = "MenuTool";
            this.Text = "Menu Tool";
            this.Load += new System.EventHandler(this.MenuTool_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPortManager;
        private System.Windows.Forms.Button btnCategoryManager;
        private System.Windows.Forms.TextBox systemStatus;
        private System.Windows.Forms.Button btnModelController;
    }
}

