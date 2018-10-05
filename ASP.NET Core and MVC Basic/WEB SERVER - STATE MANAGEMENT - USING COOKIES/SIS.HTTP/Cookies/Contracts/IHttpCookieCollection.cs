namespace SIS.HTTP.Cookies.Contracts
{
    using System.Collections.Generic;
    public interface IHttpCookieCollection:IEnumerable<IHttpCookie>
    {
        void Add(IHttpCookie cookie);
        bool ContainsCookie(string key);
        IHttpCookie GetCookie(string key);
        bool HasCookies();
    }
}
