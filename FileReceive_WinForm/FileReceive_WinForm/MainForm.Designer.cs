namespace FileReceive_WinForm
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvServState = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.btnServStop = new System.Windows.Forms.Button();
            this.btnServStart = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvServState);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 379);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "State";
            // 
            // lvServState
            // 
            this.lvServState.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvServState.HideSelection = false;
            this.lvServState.Location = new System.Drawing.Point(7, 30);
            this.lvServState.Name = "lvServState";
            this.lvServState.Size = new System.Drawing.Size(593, 343);
            this.lvServState.TabIndex = 0;
            this.lvServState.UseCompatibleStateImageBehavior = false;
            this.lvServState.View = System.Windows.Forms.View.Details;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSavePath);
            this.groupBox2.Controls.Add(this.btnServStop);
            this.groupBox2.Controls.Add(this.btnServStart);
            this.groupBox2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(13, 398);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(606, 95);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control";
            // 
            // btnSavePath
            // 
            this.btnSavePath.Location = new System.Drawing.Point(420, 29);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(180, 55);
            this.btnSavePath.TabIndex = 2;
            this.btnSavePath.Text = "SavePath";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // btnServStop
            // 
            this.btnServStop.Location = new System.Drawing.Point(215, 29);
            this.btnServStop.Name = "btnServStop";
            this.btnServStop.Size = new System.Drawing.Size(180, 55);
            this.btnServStop.TabIndex = 1;
            this.btnServStop.Text = "Stop";
            this.btnServStop.UseVisualStyleBackColor = true;
            this.btnServStop.Click += new System.EventHandler(this.btnServStop_Click);
            // 
            // btnServStart
            // 
            this.btnServStart.Location = new System.Drawing.Point(7, 29);
            this.btnServStart.Name = "btnServStart";
            this.btnServStart.Size = new System.Drawing.Size(180, 55);
            this.btnServStart.TabIndex = 0;
            this.btnServStart.Text = "Start";
            this.btnServStart.UseVisualStyleBackColor = true;
            this.btnServStart.Click += new System.EventHandler(this.btnServStart_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 505);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "FileReceive";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinForm_Closing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvServState;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.Button btnServStop;
        private System.Windows.Forms.Button btnServStart;
    }
}

