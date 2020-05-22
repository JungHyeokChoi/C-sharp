using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using FUP;
using static System.Console;

namespace FileSender
{
    class Program
    {
        const int CHUNK_SIZE = 4096;

        static void Main(string[] args)
        {
            if(args.Length < 2)
            {
                WriteLine($"Usage : {Process.GetCurrentProcess().ProcessName} <Server IP> <File Path>");
                return;
            }

            string serverIp = args[0];
            const int serverPort = 5425;
            string filepath = args[1];

            FileInfo fileinfo = new FileInfo(args[1]);
            WriteLine($"{fileinfo.FullName}");
            WriteLine($"{fileinfo.Name}");
            
            try
            {
                IPEndPoint clientAddress = new IPEndPoint(0, 0);
                IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);

                WriteLine($"Client : {clientAddress.ToString()}, Server: {serverAddress.ToString()}");

                uint msgId = 0;

                Message reqMsg = new Message();
                
                
                reqMsg.Body = new BodyRequest()
                {
                    FILESIZE = new FileInfo(filepath).Length,
                    FILENAME = System.Text.Encoding.Default.GetBytes(filepath)
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

                TcpClient client = new TcpClient(clientAddress);
                client.Connect(serverAddress);

                NetworkStream stream = client.GetStream();

                MessageUtil.Send(stream, reqMsg);

                Message rsqMsg = MessageUtil.Receive(stream);

                if(rsqMsg.Header.MSGTYPE != CONSTANTS.REP_FILE_SEND)
                {
                    WriteLine($"정상적인 서버 응답이 아닙니다. {rsqMsg.Header.MSGTYPE}");
                    return;
                }

                if(((BodyResponse)rsqMsg.Body).RESPONSE == CONSTANTS.DENIED)
                {
                    WriteLine("서버에서 파일 전송을 거부했습니다.");
                    return;
                }

                using (Stream fileStream = new FileStream(filepath, FileMode.Open))
                {
                    byte[] rbytes = new byte[CHUNK_SIZE];

                    long readValue = BitConverter.ToInt64(rbytes, 0);

                    int totalRead = 0;
                    ushort msgSeq = 0;
                    byte fragmented = (fileStream.Length < CHUNK_SIZE) ? CONSTANTS.NOT_FRAGMENTED : CONSTANTS.FRAGMENTED;

                    WriteLine($"FileSender fileStream.Length : {fileStream.Length}");

                    while (totalRead < fileStream.Length)
                    {
                        int read = fileStream.Read(rbytes, 0, CHUNK_SIZE);
                        totalRead += read;
                        Message fileMsg = new Message();

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
                    WriteLine();
                    Message rstMsg = MessageUtil.Receive(stream);

                    BodyResult result = ((BodyResult)rstMsg.Body);
                    WriteLine($"파일 전송 성공 : {result.RESULT == CONSTANTS.SUCCESS}");
                    }
                stream.Close();
                client.Close();
            }
            catch(SocketException e)
            {
                WriteLine(e);
            }
            WriteLine("클라이언트를 종료 합니다.");
        }
    }
}
