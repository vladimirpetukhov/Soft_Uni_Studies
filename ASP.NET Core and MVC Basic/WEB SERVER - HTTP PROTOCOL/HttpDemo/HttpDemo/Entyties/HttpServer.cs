namespace HttpDemo.Entyties
{
    using Contracts;

    using System;
    using System.Net;
    using System.IO;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;

    public class HttpServer : IHttpServer
    {
        private TcpListener _tcpListener;
        private bool _isWorking;
        public HttpServer()
        {
            this._tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 80);
        }
        public void Start()
        {
            this._tcpListener.Start();
            this._isWorking = true;
            Console.WriteLine("Started.");

            while (this._isWorking)
            {
                var client = this._tcpListener.AcceptTcpClient();

                var stream = client.GetStream();

                var buffer = new byte[10240];
                var readLenght = stream.Read(buffer, 0, buffer.Length);
                var requestText = Encoding.UTF8.GetString(buffer, 0, readLenght);
                Console.WriteLine(new string('=', 60));
                Console.WriteLine(requestText);

                var responseText = File.ReadAllText("../../../index.html");
                var responseBytes = Encoding.UTF8.GetBytes("HTTP/1.0 200 OK" + Environment.NewLine +
                                                           "Content-Disposition: attachment; filename=index.html" +                                            Environment.NewLine +
                                                           "Content-Length: " + responseText.Length + Environment.NewLine
                                                                                                    + Environment.NewLine
                                                                                                    + responseText);

                stream.Write(responseBytes);
            }
        }

        public void Stop()
        {
            this._isWorking = false;
        }
    }
}
