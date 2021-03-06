﻿using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Net.Sockets;
using static System.Console;

namespace EchoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 4)
            {
                WriteLine($"Usage : {Process.GetCurrentProcess().ProcessName} <Bind IP> <Bind Port> <Server IP> <Message>");
                return;
            }

            string bindIp = args[0];
            int bindPort = Convert.ToInt32(args[1]);
            string serverIp = args[2];
            const int serverPort = 5425;
            string message = args[3];

            try
            {
                IPEndPoint clientAddress = new IPEndPoint(IPAddress.Parse(bindIp), bindPort);
                IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);

                WriteLine($"Client : {clientAddress.ToString()}, Server : {serverAddress.ToString()}");

                TcpClient client = new TcpClient(clientAddress);

                client.Connect(serverAddress);

                byte[] data = Encoding.Default.GetBytes(message);

                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                WriteLine($"송신 : {message}");

                data = new byte[256];

                string responseData = "";

                int bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.Default.GetString(data, 0, data.Length);
                WriteLine($"수신 : {responseData}");

                stream.Close();
                client.Close();
            }
            catch(SocketException e)
            {
                WriteLine(e);
            }


            WriteLine("클라이언트를 종료합니다.");
        }
    }
}
