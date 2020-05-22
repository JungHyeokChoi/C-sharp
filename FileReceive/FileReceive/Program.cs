using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;
using FUP;
using static System.Console;

namespace FileReceive
{
    class Client
    {
        public TcpClient client { get; }
        public NetworkStream stream { get; }

        public Client(TcpListener server){

            client = server.AcceptTcpClient();
            stream = client.GetStream();

            WriteLine($"클라이언트 접속 : {((IPEndPoint)client.Client.RemoteEndPoint).ToString()}");
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            uint msgId = 0;

            const int bindPort = 5425;

            TcpListener server = null;

            try
            {
                IPEndPoint localAddress = new IPEndPoint(0, bindPort);

                server = new TcpListener(localAddress);
                server.Start();

                WriteLine("파일 업로드 서버 시작... ");

                Client fileClient = null;

                bool ClientLock = false;

                while (true)
                {
                    if(!ClientLock)
                    {
                        fileClient = new Client(server);

                        ClientLock = true;
                    }
                    
                    Message reqMsg = MessageUtil.Receive(fileClient.stream);
                    
                    if (reqMsg.Header.MSGTYPE == CONSTANTS.CONNECT_STATE_CHECK)
                    {
                        BodyCheck checkBody = (BodyCheck)reqMsg.Body;
                        if (checkBody.STATE == CONSTANTS.DISCONNECT)
                        {
                            ClientClose(fileClient);
                            ClientLock = false;
                            continue;
                        }

                    }

                    if (reqMsg.Header.MSGTYPE != CONSTANTS.REQ_FILE_SEND)
                    {
                        ClientClose(fileClient);
                        ClientLock = false;
                        continue;
                    }

                    BodyRequest reqBody = (BodyRequest)reqMsg.Body;

                    Write("파일 업로드 요청이 들어왔습니다. 수락하시겠습니까? Yes / No : ");
                    string answer = ReadLine();

                    Message rspMsg = new Message();
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

                    if (answer != "Yes")
                    {
                        rspMsg.Body = new BodyResponse()
                        {
                            MSGID = reqMsg.Header.MSGID,
                            RESPONSE = CONSTANTS.DENIED
                        };

                        MessageUtil.Send(fileClient.stream, rspMsg);

                        ClientClose(fileClient);
                        ClientLock = false;
                        continue;
                    }
                    else 
                        MessageUtil.Send(fileClient.stream, rspMsg);

                    WriteLine("파일 전송을 시작합니다.");

                    long fileSize = reqBody.FILESIZE;
                    string fileName = Encoding.Default.GetString(reqBody.FILENAME);
                    string saveFolder = Encoding.Default.GetString(reqBody.FOLDERNAME);

                    string dir = Directory.GetCurrentDirectory() + "\\" + saveFolder;

                    if (Directory.Exists(dir) == false)
                        Directory.CreateDirectory(dir);

                    FileStream file = new FileStream(dir + "\\" + fileName, FileMode.Create);

                    uint? dataMsgId = null;
                    ushort prevSeq = 0;
                    while ((reqMsg = MessageUtil.Receive(fileClient.stream)) != null)
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
                            WriteLine($"{prevSeq}, {reqMsg.Header.SEQ}");
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

                    WriteLine();
                    WriteLine($"수신 파일 크기 {recvFileSize} bytes");

                    Message rstMsg = new Message();
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
                        MessageUtil.Send(fileClient.stream, rstMsg);
                    else
                    {
                        rstMsg.Body = new BodyResult()
                        {
                            MSGID = reqMsg.Header.MSGID,
                            RESULT = CONSTANTS.FAIL
                        };
                        MessageUtil.Send(fileClient.stream, rstMsg);
                    }
                    WriteLine("파일 전송을 마쳤습니다.");
                }
            }
            catch (SocketException e)
            {
                WriteLine($"ErrorCode : {e.ErrorCode}");
                WriteLine(e);
            }
            finally
            {
                server.Stop();
            }
            WriteLine("서버를 종료합니다.");
        }

        static bool ClientClose(Client client)
        {
            if(client.stream != null) client.stream.Close();
            if(client.client != null) client.client.Close();

            return true;
        }
    }
}
