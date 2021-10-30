using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MultyCast_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            var ip = new IPEndPoint(IPAddress.Any, 8000);
            socket.Bind(ip);
            var multicastIP = IPAddress.Parse("224.5.5.5");
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(multicastIP, IPAddress.Any));

            while (true)
            {
                var buffer = new byte[256];
                socket.Receive(buffer);
                Console.WriteLine(Encoding.Unicode.GetString(buffer));
            }
            socket.Close();
        }
    }
}