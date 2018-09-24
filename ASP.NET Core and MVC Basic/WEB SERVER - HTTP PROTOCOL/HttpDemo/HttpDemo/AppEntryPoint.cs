using System;

namespace HttpDemo
{
    using Contracts;
    using Entyties;
    public class AppEntryPoint
    {
        public static void Main()
        {
            IHttpServer start = new HttpServer();
            start.Start();


        }
    }
}
