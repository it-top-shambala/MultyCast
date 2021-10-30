using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MultyCast_Server
{
    class Program
    {
        static void Main()
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2);
            var multicastIP = IPAddress.Parse("224.5.5.5");
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(multicastIP));
            var ip = new IPEndPoint(multicastIP, 8000);
            socket.Connect(ip);

            while (true)
            {
                socket.Send(Encoding.Unicode.GetBytes("Hello!"));
            }
            
            socket.Close();
        }
    }
}