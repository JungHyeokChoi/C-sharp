using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Net.Sockets;
using static System.Console;

namespace EchoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                WriteLine($"Usage : {Process.GetCurrentProcess().ProcessName} <Bind IP>");
                return;
            }

            string bindIp = args[0];
            const int bindPort = 5425;
            TcpListener server = null;

            try
            {
                IPEndPoint localAddress = new IPEndPoint(IPAddress.Parse(bindIp), bindPort);

                server = new TcpListener(localAddress);

                server.Start();

                WriteLine("Echo Server Start...");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    WriteLine($"Client : {((IPEndPoint)client.Client.RemoteEndPoint).ToString()}");

                    NetworkStream stream = client.GetStream();

                    int length;
                    string data = null;
                    byte[] bytes = new byte[256];

                    while((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = Encoding.Default.GetString(bytes, 0, length);
                        WriteLine(String.Format($"수신 : {data}"));

                        byte[] msg = Encoding.Default.GetBytes(data);
                        stream.Write(msg, 0, msg.Length);
                        WriteLine(String.Format($"송신 : {data}"));
                    }

                    stream.Close();
                    client.Close();

                }
            }
            catch(SocketException e)
            {
                WriteLine(e);
            }
            finally
            {
                server.Stop();
            }

            WriteLine("서버를 종료합니다.");
        }
    }
}
