
namespace DevTool.Tools.PortManager {
    partial class PortManager {
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
            this.processDataSource = new System.Windows.Forms.DataGridView();
            this.lblPid = new System.Windows.Forms.Label();
            this.processId = new System.Windows.Forms.TextBox();
            this.processStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.processProtocol = new System.Windows.Forms.TextBox();
            this.lblProcessProto = new System.Windows.Forms.Label();
            this.ipSource = new System.Windows.Forms.TextBox();
            this.lblIpSource = new System.Windows.Forms.Label();
            this.portSource = new System.Windows.Forms.TextBox();
            this.lblPortSource = new System.Windows.Forms.Label();
            this.portDestin = new System.Windows.Forms.TextBox();
            this.lblPortDestin = new System.Windows.Forms.Label();
            this.ipDestin = new System.Windows.Forms.TextBox();
            this.lblIpDestin = new System.Windows.Forms.Label();
            this.btnRefesh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.bynKillProcess = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.processDataSource)).BeginInit();
            this.SuspendLayout();
            // 
            // processDataSource
            // 
            this.processDataSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.processDataSource.Location = new System.Drawing.Point(8, 0);
            this.processDataSource.Name = "processDataSource";
            this.processDataSource.Size = new System.Drawing.Size(709, 458);
            this.processDataSource.TabIndex = 0;
            this.processDataSource.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.processDataSource_CellClick);
            this.processDataSource.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.processDataSource_ColumnHeaderMouseClick);
            // 
            // lblPid
            // 
            this.lblPid.AutoSize = true;
            this.lblPid.Location = new System.Drawing.Point(12, 472);
            this.lblPid.Name = "lblPid";
            this.lblPid.Size = new System.Drawing.Size(59, 13);
            this.lblPid.TabIndex = 1;
            this.lblPid.Text = "Process ID";
            // 
            // processId
            // 
            this.processId.Location = new System.Drawing.Point(77, 469);
            this.processId.Name = "processId";
            this.processId.Size = new System.Drawing.Size(100, 20);
            this.processId.TabIndex = 2;
            // 
            // processStatus
            // 
            this.processStatus.Location = new System.Drawing.Point(226, 469);
            this.processStatus.Name = "processStatus";
            this.processStatus.Size = new System.Drawing.Size(100, 20);
            this.processStatus.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(183, 472);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status";
            // 
            // processProtocol
            // 
            this.processProtocol.Location = new System.Drawing.Point(401, 469);
            this.processProtocol.Name = "processProtocol";
            this.processProtocol.Size = new System.Drawing.Size(100, 20);
            this.processProtocol.TabIndex = 6;
            // 
            // lblProcessProto
            // 
            this.lblProcessProto.AutoSize = true;
            this.lblProcessProto.Location = new System.Drawing.Point(332, 472);
            this.lblProcessProto.Name = "lblProcessProto";
            this.lblProcessProto.Size = new System.Drawing.Size(46, 13);
            this.lblProcessProto.TabIndex = 5;
            this.lblProcessProto.Text = "Protocol";
            // 
            // ipSource
            // 
            this.ipSource.Location = new System.Drawing.Point(77, 495);
            this.ipSource.Name = "ipSource";
            this.ipSource.Size = new System.Drawing.Size(249, 20);
            this.ipSource.TabIndex = 8;
            // 
            // lblIpSource
            // 
            this.lblIpSource.AutoSize = true;
            this.lblIpSource.Location = new System.Drawing.Point(12, 498);
            this.lblIpSource.Name = "lblIpSource";
            this.lblIpSource.Size = new System.Drawing.Size(54, 13);
            this.lblIpSource.TabIndex = 7;
            this.lblIpSource.Text = "IP Source";
            // 
            // portSource
            // 
            this.portSource.Location = new System.Drawing.Point(401, 495);
            this.portSource.Name = "portSource";
            this.portSource.Size = new System.Drawing.Size(100, 20);
            this.portSource.TabIndex = 10;
            // 
            // lblPortSource
            // 
            this.lblPortSource.AutoSize = true;
            this.lblPortSource.Location = new System.Drawing.Point(332, 498);
            this.lblPortSource.Name = "lblPortSource";
            this.lblPortSource.Size = new System.Drawing.Size(63, 13);
            this.lblPortSource.TabIndex = 9;
            this.lblPortSource.Text = "Port Source";
            // 
            // portDestin
            // 
            this.portDestin.Location = new System.Drawing.Point(401, 521);
            this.portDestin.Name = "portDestin";
            this.portDestin.Size = new System.Drawing.Size(100, 20);
            this.portDestin.TabIndex = 14;
            // 
            // lblPortDestin
            // 
            this.lblPortDestin.AutoSize = true;
            this.lblPortDestin.Location = new System.Drawing.Point(332, 524);
            this.lblPortDestin.Name = "lblPortDestin";
            this.lblPortDestin.Size = new System.Drawing.Size(59, 13);
            this.lblPortDestin.TabIndex = 13;
            this.lblPortDestin.Text = "Port Destin";
            // 
            // ipDestin
            // 
            this.ipDestin.Location = new System.Drawing.Point(77, 521);
            this.ipDestin.Name = "ipDestin";
            this.ipDestin.Size = new System.Drawing.Size(249, 20);
            this.ipDestin.TabIndex = 12;
            // 
            // lblIpDestin
            // 
            this.lblIpDestin.AutoSize = true;
            this.lblIpDestin.Location = new System.Drawing.Point(12, 524);
            this.lblIpDestin.Name = "lblIpDestin";
            this.lblIpDestin.Size = new System.Drawing.Size(50, 13);
            this.lblIpDestin.TabIndex = 11;
            this.lblIpDestin.Text = "IP Destin";
            // 
            // btnRefesh
            // 
            this.btnRefesh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRefesh.ForeColor = System.Drawing.Color.White;
            this.btnRefesh.Location = new System.Drawing.Point(507, 467);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(91, 23);
            this.btnRefesh.TabIndex = 15;
            this.btnRefesh.Text = "Refesh";
            this.btnRefesh.UseVisualStyleBackColor = false;
            this.btnRefesh.Click += new System.EventHandler(this.btnRefesh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(507, 493);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(91, 23);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // bynKillProcess
            // 
            this.bynKillProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bynKillProcess.ForeColor = System.Drawing.Color.White;
            this.bynKillProcess.Location = new System.Drawing.Point(507, 519);
            this.bynKillProcess.Name = "bynKillProcess";
            this.bynKillProcess.Size = new System.Drawing.Size(91, 23);
            this.bynKillProcess.TabIndex = 17;
            this.bynKillProcess.Text = "Kill Process";
            this.bynKillProcess.UseVisualStyleBackColor = false;
            this.bynKillProcess.Click += new System.EventHandler(this.bynKillProcess_Click);
            // 
            // result
            // 
            this.result.BackColor = System.Drawing.SystemColors.HotTrack;
            this.result.ForeColor = System.Drawing.Color.White;
            this.result.Location = new System.Drawing.Point(604, 469);
            this.result.Multiline = true;
            this.result.Name = "result";
            this.result.ReadOnly = true;
            this.result.Size = new System.Drawing.Size(105, 73);
            this.result.TabIndex = 18;
            // 
            // PortManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 553);
            this.Controls.Add(this.result);
            this.Controls.Add(this.bynKillProcess);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRefesh);
            this.Controls.Add(this.portDestin);
            this.Controls.Add(this.lblPortDestin);
            this.Controls.Add(this.ipDestin);
            this.Controls.Add(this.lblIpDestin);
            this.Controls.Add(this.portSource);
            this.Controls.Add(this.lblPortSource);
            this.Controls.Add(this.ipSource);
            this.Controls.Add(this.lblIpSource);
            this.Controls.Add(this.processProtocol);
            this.Controls.Add(this.lblProcessProto);
            this.Controls.Add(this.processStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.processId);
            this.Controls.Add(this.lblPid);
            this.Controls.Add(this.processDataSource);
            this.Name = "PortManager";
            this.Text = "Port Manager";
            this.Load += new System.EventHandler(this.PortManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.processDataSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView processDataSource;
        private System.Windows.Forms.Label lblPid;
        private System.Windows.Forms.TextBox processId;
        private System.Windows.Forms.TextBox processStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox processProtocol;
        private System.Windows.Forms.Label lblProcessProto;
        private System.Windows.Forms.TextBox ipSource;
        private System.Windows.Forms.Label lblIpSource;
        private System.Windows.Forms.TextBox portSource;
        private System.Windows.Forms.Label lblPortSource;
        private System.Windows.Forms.TextBox portDestin;
        private System.Windows.Forms.Label lblPortDestin;
        private System.Windows.Forms.TextBox ipDestin;
        private System.Windows.Forms.Label lblIpDestin;
        private System.Windows.Forms.Button btnRefesh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button bynKillProcess;
        private System.Windows.Forms.TextBox result;
    }
}