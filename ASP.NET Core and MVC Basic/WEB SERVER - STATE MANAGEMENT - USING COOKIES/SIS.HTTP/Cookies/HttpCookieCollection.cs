namespace SIS.HTTP.Cookies
{
    using Contracts;
    using Common;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly IDictionary<string, IHttpCookie> cookies;
        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, IHttpCookie>();
        }
        public void Add(IHttpCookie cookie)
        {
            CoreValidator.ThrowIfNull(cookie, nameof(cookie.Key));
            this.cookies.Add(cookie.Key, cookie);
        }

        public bool ContainsCookie(string key)
        {
            CoreValidator.ThrowIfNull(key, nameof(key));

            return cookies.ContainsKey(key);
        }

        public IHttpCookie GetCookie(string key)
        {
            CoreValidator.ThrowIfNull(key, nameof(key));

            return this.cookies.Where(k => k.Key == key)
                .FirstOrDefault().Value;
        }

        public bool HasCookies()
        {
            return this.cookies.Count > 0;
        }

        public override string ToString()
        {
            return String.Join("; ",cookies.Values);
        }

        public IEnumerator<IHttpCookie> GetEnumerator()
        {
            foreach (var cookie in this.cookies)
            {
                yield return cookie.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
