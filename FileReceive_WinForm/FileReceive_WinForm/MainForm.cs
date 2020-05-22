using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FUP;

namespace FileReceive_WinForm
{
    delegate void AcceptClient();
    delegate void CloseClient();

    public partial class MainForm : Form
    {
        event AcceptClient AcceptEvent;
        event CloseClient CloseEvent;

        Thread clientThread;

        TcpListener server { get; set; }
        _TcpClient client { get; set; }

        string clntInfo { get; set; }
        string directory = "";

        bool IsStart = false;

        uint msgId { get; set; }

        public MainForm()
        {
            InitializeComponent();

            lvServState.Columns.Add("State", 300);

            btnServStop.Enabled = false;
            btnSavePath.Enabled = false;
        }

        private void btnServStart_Click(object sender, EventArgs e)
        {
            AcceptEvent += new AcceptClient(AcceptEventHandler);
            CloseEvent += new CloseClient(CloseEventHandler);

            lvServState.Items.Add("연결 대기 중...");

            clientThread = new Thread(new ThreadStart(Accept));
            clientThread.IsBackground = true;
            clientThread.Start();
        }
        private void btnServStop_Click(object sender, EventArgs e)
        {
            ClientClose();
            ServerStop();
            
            btnServStart.Enabled = true;
            btnServStop.Enabled = false;
            btnSavePath.Enabled = false;

            lvServState.Items.Add("클라이언트 종료 : " + clntInfo);
            lvServState.Items.Add("서버를 종료합니다.");
        }
        private void btnSavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                directory = dialog.SelectedPath;
                lvServState.Items.Add("저장 위치 : " + directory);
            }
        }
        private void WinForm_Closing(object sender, FormClosingEventArgs e)
        {
            ClientClose();
            ServerStop();
        }

        private void Accept()
        {
            TcpClient socket = null;
            const int bindPort = 5425;

            if (!IsStart)
            {
                IPAddress ip = IPAddress.Parse("192.168.0.6");
                IPEndPoint LocalAddress = new IPEndPoint(ip, bindPort);
                server = new TcpListener(LocalAddress);
                server.Start();
            }
            
            while (true)
            {
                socket = server.AcceptTcpClient();

                client = new _TcpClient();
                client.client = socket;
                client.stream = socket.GetStream();
                clntInfo = ((IPEndPoint)socket.Client.RemoteEndPoint).ToString();

                AcceptEvent();
                IsStart = true;

                FileReceive();
            }
        }
        public void AcceptEventHandler()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(delegate ()
                {
                    lvServState.Items.Add("클라이언트 접속 : " + clntInfo);
                    lvServState.Items.Add("파일 업로드 서버 시작... ");
                }));
            }
            else
            {
                lvServState.Items.Add("클라이언트 접속 : " + clntInfo);
                lvServState.Items.Add("파일 업로드 서버 시작... ");
            }

            if (IsStart == false)
            {
                btnServStart.Enabled = false;
                btnServStop.Enabled = true;
                btnSavePath.Enabled = true;
            }
        }
        public void CloseEventHandler()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(delegate ()
                {
                    lvServState.Items.Add("클라이언트 종료 : " + clntInfo);
                    clntInfo = "";
                }));
            }
            else
            {
                lvServState.Items.Add("클라이언트 종료 : " + clntInfo);
                clntInfo = "";
            }
            ClientClose();
            Accept();
        }
        public void ServerStop()
        {
            IsStart = false;
            if (server != null) server.Stop();
        }
        public void ClientClose()
        {
            if (client.stream != null) client.stream.Close();
            if (client.client != null) client.client.Close();
            //if (client != null) client = null;
        }
        public void FileReceive()
        {
            while (true)
            {
                FUP.Message reqMsg = MessageUtil.Receive(client.stream);

                if(reqMsg.Header.MSGTYPE == CONSTANTS.CONNECT_STATE_CHECK)
                {
                    BodyCheck body = (BodyCheck)reqMsg.Body;
                    if(body.STATE == CONSTANTS.DISCONNECT)
                    {
                        CloseEvent();
                        continue;
                    }

                }

                if (reqMsg.Header.MSGTYPE != CONSTANTS.REQ_FILE_SEND)
                {
                    CloseEvent();
                    continue;
                }

                BodyRequest reqBody = (BodyRequest)reqMsg.Body;

                var anwser = MessageBox.Show("파일 업로드 요청이 들어왔습니다. 수락하시겠습니까? Yes / No : ",
                    "파일 업로드 요청", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                FUP.Message rspMsg = new FUP.Message();
                rspMsg.Body = new BodyResponse()
                {
                    MSGID = reqMsg.Header.MSGID,
                    RESPONSE = CONSTANTS.ACCEPTED
                };
                rspMsg.Header = new Header()
                {
                    MSGID = msgId++,
                    MSGTYPE = CONSTANTS.REP_FILE_SEND,
                    BODYLEN = (uint)rspMsg.Body.GetSize(),
                    FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                    LASTMSG = CONSTANTS.NOT_LASTMSG,
                    SEQ = 0
                };

                if (anwser == DialogResult.No)
                {
                    rspMsg.Body = new BodyResponse()
                    {
                        MSGID = reqMsg.Header.MSGID,
                        RESPONSE = CONSTANTS.DENIED
                    };

                    MessageUtil.Send(client.stream, rspMsg);

                    CloseEvent();
                    continue;
                }
                else
                    MessageUtil.Send(client.stream, rspMsg);

                lvServState.Items.Add("파일 전송을 시작합니다.");

                long fileSize = reqBody.FILESIZE;
                string fileName = Encoding.Default.GetString(reqBody.FILENAME);
                string saveFolder = Encoding.Default.GetString(reqBody.FOLDERNAME);
                string saveDir = "";

                if (directory.Length == 0)
                {
                    saveDir = Directory.GetCurrentDirectory();
                    saveDir = saveDir + "\\" + saveFolder;
                }
                else
                {
                    saveDir = directory + "\\" + saveFolder;
                }

                if (Directory.Exists(saveDir) == false)
                    Directory.CreateDirectory(saveDir);

                FileStream file = new FileStream(saveDir + "\\" + fileName, FileMode.Create);

                uint? dataMsgId = null;
                ushort prevSeq = 0;
                while ((reqMsg = MessageUtil.Receive(client.stream)) != null)
                {
                    if (reqMsg.Header.MSGTYPE != CONSTANTS.FILE_SEND_DATA)
                        break;
                    if (dataMsgId == null)
                        dataMsgId = reqMsg.Header.MSGID;
                    else
                    {
                        if (dataMsgId != reqMsg.Header.MSGID)
                            break;
                    }
                    if (prevSeq++ != reqMsg.Header.SEQ)
                    {
                        lvServState.Items.Add($"{prevSeq}, {reqMsg.Header.SEQ}");
                        break;
                    }

                    file.Write(reqMsg.Body.GetBytes(), 0, reqMsg.Body.GetSize());

                    if (reqMsg.Header.FRAGMENTED == CONSTANTS.NOT_FRAGMENTED)
                        break;
                    if (reqMsg.Header.LASTMSG == CONSTANTS.LASTMSG)
                        break;
                }

                long recvFileSize = file.Length;
                file.Close();

                lvServState.Items.Add("");
                lvServState.Items.Add($"수신 파일 크기 {recvFileSize} bytes");

                FUP.Message rstMsg = new FUP.Message();
                rstMsg.Body = new BodyResult()
                {
                    MSGID = reqMsg.Header.MSGID,
                    RESULT = CONSTANTS.SUCCESS
                };
                rstMsg.Header = new Header()
                {
                    MSGID = msgId++,
                    MSGTYPE = CONSTANTS.FILE_SEND_RES,
                    BODYLEN = (uint)rstMsg.Body.GetSize(),
                    FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                    LASTMSG = CONSTANTS.LASTMSG,
                    SEQ = 0
                };
                if (fileSize == recvFileSize)
                    MessageUtil.Send(client.stream, rstMsg);
                else
                {
                    rstMsg.Body = new BodyResult()
                    {
                        MSGID = reqMsg.Header.MSGID,
                        RESULT = CONSTANTS.FAIL
                    };
                    MessageUtil.Send(client.stream, rstMsg);
                }
                lvServState.Items.Add("파일 전송을 마쳤습니다.");
            }
        }
    }
}

