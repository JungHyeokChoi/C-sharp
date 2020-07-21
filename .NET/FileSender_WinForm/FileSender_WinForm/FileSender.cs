using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using FUP;
using System.Windows.Forms;
using System.Drawing;

namespace FileSender_WinForm
{
    public partial class FileSender : Form
    {
        private TcpClient client { get; set; }
        private NetworkStream stream;
       
        uint msgId = 0;
        public FileSender()
        {
            InitializeComponent();

            lvState.Columns.Add("State",300);

            btnDisconnection.Enabled = false;
            btnSend.Enabled = false;
        }
        private void FileSender_Load(object sender, EventArgs e)
        {

        }
        private void ServFileSend_Enter(object sender, EventArgs e)
        {

        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Connection(txtServerIp.Text.ToString(), txtServerPort.Text.ToString());
            }
            catch (FormatException f)
            {
                if (txtServerIp.TextLength == 0 || txtServerPort.TextLength == 0)
                {
                    MessageBox.Show("Server IP, Port를 입력해주세요.", "Server Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnDisconnection_Click(object sender, EventArgs e)
        {
            Disconnection();
        }
        private void btnFindSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtFilePath.Text = dlg.FileName;
        }
        private void BtnSend_Click(object sender, EventArgs e)
        {
            if(txtFilePath.TextLength == 0)
            {
                MessageBox.Show("저장할 파일이 없습니다.", "Send Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            { 
                FileSend(new FileInfo(txtFilePath.Text.ToString()), txtSaveFolder.Text.ToString());
                txtFilePath.Clear();
                txtSaveFolder.Clear();
            }
        }
        private void WinForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (stream != null) client.Close();
            if (client != null) client.Close();

        }

        void Connection(string Ip, string Port)
        {
            string serverIp = Ip;
            int serverPort = Convert.ToInt32(Port);
            try
            {
                IPEndPoint clientAddress = new IPEndPoint(0, 0);
                IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);

                client = new TcpClient(clientAddress);
                client.Connect(serverAddress);
                stream = client.GetStream();

                ConnectedCheck();
            }
            catch(SocketException e)
            {                
                MessageBox.Show(e.Message, "Server Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Disconnection()
        {
            FUP.Message checkMsg = new FUP.Message();

            checkMsg.Body = new BodyCheck()
            {
                STATE = CONSTANTS.DISCONNECT
            };
            checkMsg.Header = new Header()
            {
                MSGID = 0,
                MSGTYPE = CONSTANTS.CONNECT_STATE_CHECK,
                BODYLEN = (uint)checkMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.LASTMSG,
                SEQ = 0
            };

            MessageUtil.Send(stream, checkMsg);

            if (stream != null) stream.Close();
            if (client != null) client.Close();

            ConnectedCheck();
        }
        void ConnectedCheck()
        {
            if (client.Connected == true && lblConncetState.ForeColor == Color.Red)
            {
                lblConncetState.ForeColor = Color.Green;
                lblConncetState.Text = "   Connection";

                btnConnect.Enabled = false;
                btnDisconnection.Enabled = true;
                btnSend.Enabled = true;

                lvState.Items.Add("서버에 연결되었습니다.");
            }
            else if (client.Connected == false && lblConncetState.ForeColor == Color.Green)
            {
                lblConncetState.ForeColor = Color.Red;
                lblConncetState.Text = "Disconnection";

                btnConnect.Enabled = true;
                btnDisconnection.Enabled = false;
                btnSend.Enabled = false;

                lvState.Items.Add("서버에 연결이 끊겼습니다.");
            }
        }
        void FileSend(FileInfo filepath, string saveFolder)
        {
            const int CHUNK_SIZE = 4096;

            if (saveFolder.Length == 0)
            {
                saveFolder = "upload";
            }

            FUP.Message reqMsg = new FUP.Message();

            reqMsg.Body = new BodyRequest()
            {
                FILESIZE = filepath.Length,
                FOLDERSIZE = saveFolder.Length,
                FILENAME = System.Text.Encoding.Default.GetBytes(filepath.Name),
                FOLDERNAME = System.Text.Encoding.Default.GetBytes(saveFolder)
            };
            reqMsg.Header = new Header()
            {
                MSGID = msgId++,
                MSGTYPE = CONSTANTS.REQ_FILE_SEND,
                BODYLEN = (uint)reqMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.NOT_LASTMSG,
                SEQ = 0
            };
            MessageUtil.Send(stream, reqMsg);

            FUP.Message rsqMsg = MessageUtil.Receive(stream);

            if (rsqMsg.Header.MSGTYPE != CONSTANTS.REP_FILE_SEND)
            {
                lvState.Items.Add($"정상적인 서버 응답이 아닙니다. {rsqMsg.Header.MSGTYPE}");
                ConnectedCheck();
                return;
            }

            if (((BodyResponse)rsqMsg.Body).RESPONSE == CONSTANTS.DENIED)
            {
                lvState.Items.Add("서버에서 파일 전송을 거부했습니다.");
                ConnectedCheck();
                return;
            }

            using (FileStream fileStream = new FileStream(filepath.FullName, FileMode.Open))
            {
                byte[] rbytes = new byte[CHUNK_SIZE];

                long readValue = BitConverter.ToInt64(rbytes, 0);

                int totalRead = 0;
                ushort msgSeq = 0;
                byte fragmented = (fileStream.Length < CHUNK_SIZE) ? CONSTANTS.NOT_FRAGMENTED : CONSTANTS.FRAGMENTED;


                DateTime startTime = DateTime.Now;
                while (totalRead < fileStream.Length)
                {
                    int read = fileStream.Read(rbytes, 0, CHUNK_SIZE);
                    totalRead += read;
                    FUP.Message fileMsg = new FUP.Message();

                    byte[] sendBytes = new byte[read];
                    Array.Copy(rbytes, 0, sendBytes, 0, read);

                    fileMsg.Body = new BodyData(sendBytes);
                    fileMsg.Header = new Header()
                    {
                        MSGID = msgId,
                        MSGTYPE = CONSTANTS.FILE_SEND_DATA,
                        BODYLEN = (uint)fileMsg.Body.GetSize(),
                        FRAGMENTED = CONSTANTS.FRAGMENTED,
                        LASTMSG = (totalRead < fileStream.Length) ? CONSTANTS.NOT_LASTMSG : CONSTANTS.LASTMSG,
                        SEQ = msgSeq++
                    };
                    MessageUtil.Send(stream, fileMsg);
                }

                FUP.Message rstMsg = MessageUtil.Receive(stream);

                BodyResult result = ((BodyResult)rstMsg.Body);

                TimeSpan resultTime = DateTime.Now - startTime;
                string RcvResult = result.RESULT == CONSTANTS.SUCCESS ? "성공" : "실패";
                
                lvState.Items.Add($"파일 전송 {RcvResult}");
                lvState.Items.Add($"전송 시간 : {resultTime}");
                lvState.Items.Add($"저장 폴더 : {saveFolder}");
            }
        }

    }

}

