﻿namespace SIS.HTTP.Requests
{
    using System.Collections.Generic;
    using Enums;
    using Headers;
    using Cookies.Contracts;
    using SIS.HTTP.Sessions.Contracts;

    public interface IHttpRequest
    {
        string Path { get; }

        string Url { get; }

        Dictionary<string, object> FormData { get; }

        Dictionary<string, object> QueryData { get; }

        IHttpHeaderCollection Headers { get; }

        HttpRequestMethod RequestMethod { get; }

        IHttpCookieCollection Cookies { get; }
        IHttpSession Session { get; set; }
    }
}
