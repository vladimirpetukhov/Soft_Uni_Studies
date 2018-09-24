using System;
using System.Collections.Generic;
using System.Text;

namespace HttpDemo.Contracts
{
    public interface IHttpServer
    {
        void Start();

        void Stop();
    }
}
