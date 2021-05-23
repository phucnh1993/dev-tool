
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
            this.SuspendLayout();
            // 
            // btnPortManager
            // 
            this.btnPortManager.Location = new System.Drawing.Point(12, 12);
            this.btnPortManager.Name = "btnPortManager";
            this.btnPortManager.Size = new System.Drawing.Size(104, 23);
            this.btnPortManager.TabIndex = 0;
            this.btnPortManager.Text = "Port Manager";
            this.btnPortManager.UseVisualStyleBackColor = true;
            this.btnPortManager.Click += new System.EventHandler(this.btnPortManager_Click);
            // 
            // btnCategoryManager
            // 
            this.btnCategoryManager.Location = new System.Drawing.Point(122, 12);
            this.btnCategoryManager.Name = "btnCategoryManager";
            this.btnCategoryManager.Size = new System.Drawing.Size(116, 23);
            this.btnCategoryManager.TabIndex = 1;
            this.btnCategoryManager.Text = "Category Manager";
            this.btnCategoryManager.UseVisualStyleBackColor = true;
            this.btnCategoryManager.Click += new System.EventHandler(this.btnCategoryManager_Click);
            // 
            // MenuTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 56);
            this.Controls.Add(this.btnCategoryManager);
            this.Controls.Add(this.btnPortManager);
            this.Name = "MenuTool";
            this.Text = "Menu Tool";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPortManager;
        private System.Windows.Forms.Button btnCategoryManager;
    }
}

