namespace FileSender_WinForm
{
    partial class FileSender
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.SevrConnet = new System.Windows.Forms.GroupBox();
            this.btnDisconnection = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.txtServerIp = new System.Windows.Forms.TextBox();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.lblServerIp = new System.Windows.Forms.Label();
            this.lblConncetState = new System.Windows.Forms.Label();
            this.ServFileSend = new System.Windows.Forms.GroupBox();
            this.txtSaveFolder = new System.Windows.Forms.TextBox();
            this.lblSaveFolder = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnFindSource = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvState = new System.Windows.Forms.ListView();
            this.SevrConnet.SuspendLayout();
            this.ServFileSend.SuspendLayout();
            this.SuspendLayout();
            // 
            // SevrConnet
            // 
            this.SevrConnet.Controls.Add(this.btnDisconnection);
            this.SevrConnet.Controls.Add(this.btnConnect);
            this.SevrConnet.Controls.Add(this.txtServerPort);
            this.SevrConnet.Controls.Add(this.txtServerIp);
            this.SevrConnet.Controls.Add(this.lblServerPort);
            this.SevrConnet.Controls.Add(this.lblServerIp);
            this.SevrConnet.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SevrConnet.Location = new System.Drawing.Point(12, 30);
            this.SevrConnet.Name = "SevrConnet";
            this.SevrConnet.Size = new System.Drawing.Size(489, 177);
            this.SevrConnet.TabIndex = 0;
            this.SevrConnet.TabStop = false;
            this.SevrConnet.Text = "Server";
            // 
            // btnDisconnection
            // 
            this.btnDisconnection.Location = new System.Drawing.Point(304, 128);
            this.btnDisconnection.Name = "btnDisconnection";
            this.btnDisconnection.Size = new System.Drawing.Size(170, 35);
            this.btnDisconnection.TabIndex = 5;
            this.btnDisconnection.Text = "Disconnection";
            this.btnDisconnection.UseVisualStyleBackColor = true;
            this.btnDisconnection.Click += new System.EventHandler(this.btnDisconnection_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(74, 128);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(170, 35);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(74, 74);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(400, 30);
            this.txtServerPort.TabIndex = 3;
            // 
            // txtServerIp
            // 
            this.txtServerIp.Location = new System.Drawing.Point(74, 30);
            this.txtServerIp.Name = "txtServerIp";
            this.txtServerIp.Size = new System.Drawing.Size(400, 30);
            this.txtServerIp.TabIndex = 2;
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblServerPort.Location = new System.Drawing.Point(7, 77);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(71, 20);
            this.lblServerPort.TabIndex = 1;
            this.lblServerPort.Text = "Port : ";
            // 
            // lblServerIp
            // 
            this.lblServerIp.AutoSize = true;
            this.lblServerIp.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblServerIp.Location = new System.Drawing.Point(7, 33);
            this.lblServerIp.Name = "lblServerIp";
            this.lblServerIp.Size = new System.Drawing.Size(50, 20);
            this.lblServerIp.TabIndex = 0;
            this.lblServerIp.Text = "IP : ";
            // 
            // lblConncetState
            // 
            this.lblConncetState.AutoSize = true;
            this.lblConncetState.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblConncetState.ForeColor = System.Drawing.Color.Red;
            this.lblConncetState.Location = new System.Drawing.Point(380, 10);
            this.lblConncetState.Name = "lblConncetState";
            this.lblConncetState.Size = new System.Drawing.Size(120, 17);
            this.lblConncetState.TabIndex = 1;
            this.lblConncetState.Text = "Disconnected";
            // 
            // ServFileSend
            // 
            this.ServFileSend.Controls.Add(this.txtSaveFolder);
            this.ServFileSend.Controls.Add(this.lblSaveFolder);
            this.ServFileSend.Controls.Add(this.btnSend);
            this.ServFileSend.Controls.Add(this.btnFindSource);
            this.ServFileSend.Controls.Add(this.txtFilePath);
            this.ServFileSend.Controls.Add(this.label1);
            this.ServFileSend.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ServFileSend.Location = new System.Drawing.Point(12, 229);
            this.ServFileSend.Name = "ServFileSend";
            this.ServFileSend.Size = new System.Drawing.Size(489, 165);
            this.ServFileSend.TabIndex = 2;
            this.ServFileSend.TabStop = false;
            this.ServFileSend.Text = "FileSend";
            this.ServFileSend.Enter += new System.EventHandler(this.ServFileSend_Enter);
            // 
            // txtSaveFolder
            // 
            this.txtSaveFolder.Location = new System.Drawing.Point(74, 75);
            this.txtSaveFolder.Name = "txtSaveFolder";
            this.txtSaveFolder.Size = new System.Drawing.Size(327, 30);
            this.txtSaveFolder.TabIndex = 11;
            // 
            // lblSaveFolder
            // 
            this.lblSaveFolder.AutoSize = true;
            this.lblSaveFolder.Location = new System.Drawing.Point(1, 78);
            this.lblSaveFolder.Name = "lblSaveFolder";
            this.lblSaveFolder.Size = new System.Drawing.Size(73, 20);
            this.lblSaveFolder.TabIndex = 10;
            this.lblSaveFolder.Text = "Save :";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(174, 124);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(170, 35);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // btnFindSource
            // 
            this.btnFindSource.Location = new System.Drawing.Point(414, 31);
            this.btnFindSource.Name = "btnFindSource";
            this.btnFindSource.Size = new System.Drawing.Size(60, 30);
            this.btnFindSource.TabIndex = 7;
            this.btnFindSource.Text = "...";
            this.btnFindSource.UseVisualStyleBackColor = true;
            this.btnFindSource.Click += new System.EventHandler(this.btnFindSource_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(74, 33);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(327, 30);
            this.txtFilePath.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path :";
            // 
            // lvState
            // 
            this.lvState.HideSelection = false;
            this.lvState.Location = new System.Drawing.Point(12, 400);
            this.lvState.Name = "lvState";
            this.lvState.Size = new System.Drawing.Size(488, 165);
            this.lvState.TabIndex = 3;
            this.lvState.UseCompatibleStateImageBehavior = false;
            this.lvState.View = System.Windows.Forms.View.Details;
            // 
            // FileSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(526, 577);
            this.Controls.Add(this.lvState);
            this.Controls.Add(this.ServFileSend);
            this.Controls.Add(this.lblConncetState);
            this.Controls.Add(this.SevrConnet);
            this.Name = "FileSender";
            this.Text = "FileSender";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinForm_Closing);
            this.Load += new System.EventHandler(this.FileSender_Load);
            this.SevrConnet.ResumeLayout(false);
            this.SevrConnet.PerformLayout();
            this.ServFileSend.ResumeLayout(false);
            this.ServFileSend.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox SevrConnet;
        private System.Windows.Forms.Label lblServerIp;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.TextBox txtServerIp;
        private System.Windows.Forms.Label lblConncetState;
        private System.Windows.Forms.Button btnDisconnection;
        private System.Windows.Forms.GroupBox ServFileSend;
        private System.Windows.Forms.Button btnFindSource;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListView lvState;
        private System.Windows.Forms.Label lblSaveFolder;
        private System.Windows.Forms.TextBox txtSaveFolder;
    }
}

