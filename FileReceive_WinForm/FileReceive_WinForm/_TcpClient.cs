using System.Net.Sockets;

namespace FileReceive_WinForm
{
    public class _TcpClient
    {
        public TcpClient client { get; set; }
        public NetworkStream stream { get; set;  }

        public _TcpClient() { }
    }
}

