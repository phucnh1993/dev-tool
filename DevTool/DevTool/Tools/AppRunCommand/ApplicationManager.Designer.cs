
namespace DevTool.Tools.AppRunCommand {
    partial class ApplicationManager {
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
            this.dataApplications = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.applicationId = new System.Windows.Forms.TextBox();
            this.applicationType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.applicationName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveChange = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefesh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.dataCommandLine = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.commandId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.commandContent = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.commandDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSaveChangeCmd = new System.Windows.Forms.Button();
            this.btnDeleteCmd = new System.Windows.Forms.Button();
            this.btnRefeshCmd = new System.Windows.Forms.Button();
            this.btnCleanCmd = new System.Windows.Forms.Button();
            this.btnExportCmd = new System.Windows.Forms.Button();
            this.btnImportCmd = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataApplications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataCommandLine)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "List Application:";
            // 
            // dataApplications
            // 
            this.dataApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataApplications.Location = new System.Drawing.Point(0, 25);
            this.dataApplications.Name = "dataApplications";
            this.dataApplications.Size = new System.Drawing.Size(458, 211);
            this.dataApplications.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID:";
            // 
            // applicationId
            // 
            this.applicationId.Location = new System.Drawing.Point(109, 242);
            this.applicationId.Name = "applicationId";
            this.applicationId.ReadOnly = true;
            this.applicationId.Size = new System.Drawing.Size(155, 20);
            this.applicationId.TabIndex = 3;
            // 
            // applicationType
            // 
            this.applicationType.Location = new System.Drawing.Point(109, 268);
            this.applicationType.Name = "applicationType";
            this.applicationType.Size = new System.Drawing.Size(155, 20);
            this.applicationType.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Application Type:";
            // 
            // applicationName
            // 
            this.applicationName.Location = new System.Drawing.Point(109, 294);
            this.applicationName.Name = "applicationName";
            this.applicationName.Size = new System.Drawing.Size(155, 20);
            this.applicationName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Application Name:";
            // 
            // btnSaveChange
            // 
            this.btnSaveChange.Location = new System.Drawing.Point(270, 239);
            this.btnSaveChange.Name = "btnSaveChange";
            this.btnSaveChange.Size = new System.Drawing.Size(95, 23);
            this.btnSaveChange.TabIndex = 8;
            this.btnSaveChange.Text = "Save Change";
            this.btnSaveChange.UseVisualStyleBackColor = true;
            this.btnSaveChange.Click += new System.EventHandler(this.btnSaveChange_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(371, 239);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnRefesh
            // 
            this.btnRefesh.Location = new System.Drawing.Point(270, 266);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(95, 23);
            this.btnRefesh.TabIndex = 10;
            this.btnRefesh.Text = "Refesh";
            this.btnRefesh.UseVisualStyleBackColor = true;
            this.btnRefesh.Click += new System.EventHandler(this.btnRefesh_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(371, 266);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(371, 292);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 12;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(270, 292);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(95, 23);
            this.btnClean.TabIndex = 13;
            this.btnClean.Text = "Clean";
            this.btnClean.UseVisualStyleBackColor = true;
            // 
            // dataCommandLine
            // 
            this.dataCommandLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCommandLine.Location = new System.Drawing.Point(0, 344);
            this.dataCommandLine.Name = "dataCommandLine";
            this.dataCommandLine.Size = new System.Drawing.Size(458, 218);
            this.dataCommandLine.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "List Command Line:";
            // 
            // commandId
            // 
            this.commandId.Location = new System.Drawing.Point(83, 568);
            this.commandId.Name = "commandId";
            this.commandId.ReadOnly = true;
            this.commandId.Size = new System.Drawing.Size(117, 20);
            this.commandId.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 571);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "ID:";
            // 
            // commandContent
            // 
            this.commandContent.Location = new System.Drawing.Point(83, 594);
            this.commandContent.Name = "commandContent";
            this.commandContent.Size = new System.Drawing.Size(363, 20);
            this.commandContent.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 597);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Content:";
            // 
            // commandDescription
            // 
            this.commandDescription.Location = new System.Drawing.Point(83, 620);
            this.commandDescription.Name = "commandDescription";
            this.commandDescription.Size = new System.Drawing.Size(363, 20);
            this.commandDescription.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 623);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Description:";
            // 
            // btnSaveChangeCmd
            // 
            this.btnSaveChangeCmd.Location = new System.Drawing.Point(231, 566);
            this.btnSaveChangeCmd.Name = "btnSaveChangeCmd";
            this.btnSaveChangeCmd.Size = new System.Drawing.Size(95, 23);
            this.btnSaveChangeCmd.TabIndex = 22;
            this.btnSaveChangeCmd.Text = "Save Change";
            this.btnSaveChangeCmd.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCmd
            // 
            this.btnDeleteCmd.Location = new System.Drawing.Point(332, 566);
            this.btnDeleteCmd.Name = "btnDeleteCmd";
            this.btnDeleteCmd.Size = new System.Drawing.Size(50, 23);
            this.btnDeleteCmd.TabIndex = 23;
            this.btnDeleteCmd.Text = "Delete";
            this.btnDeleteCmd.UseVisualStyleBackColor = true;
            // 
            // btnRefeshCmd
            // 
            this.btnRefeshCmd.Location = new System.Drawing.Point(388, 566);
            this.btnRefeshCmd.Name = "btnRefeshCmd";
            this.btnRefeshCmd.Size = new System.Drawing.Size(58, 23);
            this.btnRefeshCmd.TabIndex = 24;
            this.btnRefeshCmd.Text = "Refesh";
            this.btnRefeshCmd.UseVisualStyleBackColor = true;
            // 
            // btnCleanCmd
            // 
            this.btnCleanCmd.Location = new System.Drawing.Point(273, 647);
            this.btnCleanCmd.Name = "btnCleanCmd";
            this.btnCleanCmd.Size = new System.Drawing.Size(53, 23);
            this.btnCleanCmd.TabIndex = 25;
            this.btnCleanCmd.Text = "Clean";
            this.btnCleanCmd.UseVisualStyleBackColor = true;
            // 
            // btnExportCmd
            // 
            this.btnExportCmd.Location = new System.Drawing.Point(332, 647);
            this.btnExportCmd.Name = "btnExportCmd";
            this.btnExportCmd.Size = new System.Drawing.Size(50, 23);
            this.btnExportCmd.TabIndex = 26;
            this.btnExportCmd.Text = "Export";
            this.btnExportCmd.UseVisualStyleBackColor = true;
            // 
            // btnImportCmd
            // 
            this.btnImportCmd.Location = new System.Drawing.Point(388, 647);
            this.btnImportCmd.Name = "btnImportCmd";
            this.btnImportCmd.Size = new System.Drawing.Size(58, 23);
            this.btnImportCmd.TabIndex = 27;
            this.btnImportCmd.Text = "Import";
            this.btnImportCmd.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(210, 646);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(57, 23);
            this.btnDown.TabIndex = 28;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(129, 646);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 29;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // ApplicationManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 682);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnImportCmd);
            this.Controls.Add(this.btnExportCmd);
            this.Controls.Add(this.btnCleanCmd);
            this.Controls.Add(this.btnRefeshCmd);
            this.Controls.Add(this.btnDeleteCmd);
            this.Controls.Add(this.btnSaveChangeCmd);
            this.Controls.Add(this.commandDescription);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.commandContent);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.commandId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataCommandLine);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnRefesh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSaveChange);
            this.Controls.Add(this.applicationName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.applicationType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.applicationId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataApplications);
            this.Controls.Add(this.label1);
            this.Name = "ApplicationManager";
            this.Text = "Application Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ApplicationManager_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ApplicationManager_FormClosed);
            this.Load += new System.EventHandler(this.ApplicationManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataApplications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataCommandLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataApplications;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox applicationId;
        private System.Windows.Forms.TextBox applicationType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox applicationName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveChange;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefesh;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.DataGridView dataCommandLine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox commandId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox commandContent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox commandDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSaveChangeCmd;
        private System.Windows.Forms.Button btnDeleteCmd;
        private System.Windows.Forms.Button btnRefeshCmd;
        private System.Windows.Forms.Button btnCleanCmd;
        private System.Windows.Forms.Button btnExportCmd;
        private System.Windows.Forms.Button btnImportCmd;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
    }
}