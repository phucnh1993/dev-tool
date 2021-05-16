
namespace DevelopmentToop {
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
            this.labApplication = new System.Windows.Forms.Label();
            this.boxApplication = new System.Windows.Forms.ComboBox();
            this.btnUse = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labApplication
            // 
            this.labApplication.AutoSize = true;
            this.labApplication.Location = new System.Drawing.Point(17, 15);
            this.labApplication.Name = "labApplication";
            this.labApplication.Size = new System.Drawing.Size(172, 16);
            this.labApplication.TabIndex = 0;
            this.labApplication.Text = "Danh sách những ứng dụng:";
            // 
            // boxApplication
            // 
            this.boxApplication.FormattingEnabled = true;
            this.boxApplication.Location = new System.Drawing.Point(195, 12);
            this.boxApplication.Name = "boxApplication";
            this.boxApplication.Size = new System.Drawing.Size(442, 24);
            this.boxApplication.TabIndex = 1;
            this.boxApplication.SelectedIndexChanged += new System.EventHandler(this.boxApplication_SelectedIndexChanged);
            // 
            // btnUse
            // 
            this.btnUse.FlatAppearance.BorderSize = 2;
            this.btnUse.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUse.Location = new System.Drawing.Point(643, 12);
            this.btnUse.Name = "btnUse";
            this.btnUse.Size = new System.Drawing.Size(75, 23);
            this.btnUse.TabIndex = 2;
            this.btnUse.Text = "Sử dụng";
            this.btnUse.UseVisualStyleBackColor = true;
            this.btnUse.Click += new System.EventHandler(this.btnUse_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(20, 42);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(698, 397);
            this.txtDescription.TabIndex = 3;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(734, 454);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnUse);
            this.Controls.Add(this.boxApplication);
            this.Controls.Add(this.labApplication);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Menu";
            this.Text = "Danh mục";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labApplication;
        private System.Windows.Forms.ComboBox boxApplication;
        private System.Windows.Forms.Button btnUse;
        private System.Windows.Forms.TextBox txtDescription;
    }
}

