namespace SIS.HTTP.Responses
{
    using Cookies;
    using Cookies.Contracts;
    using Enums;
    using Headers;
    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }

        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }

        byte[] Content { get; set; }

        void AddHeader(HttpHeader header);

       void AddCookie(HttpCookie cookie);

        byte[] GetBytes();
    }
}