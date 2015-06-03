// -----------------------------------------------------------------------
// <copyright file="Client.cs" company="xsDevelopment">
//   Attribution-NonCommercial-ShareAlike 3.0 Unported (CC BY-NC-SA 3.0)
//   All Rights Reserved - See License.txt for more details
// </copyright>
// -----------------------------------------------------------------------
namespace serverExample
{
    using System.IO;
    using System.Net.Sockets;
    using System.Threading;

    public class Client
    {
        public Client(TcpClient client)
        {
            var ns = client.GetStream();
            StreamReader = new StreamReader(ns);
            StreamWriter = new StreamWriter(ns);
            TcpClient = client;
        }

        public TcpClient TcpClient;
        public StreamReader StreamReader;
        public StreamWriter StreamWriter;
        public Thread ReadThread;
    }
}