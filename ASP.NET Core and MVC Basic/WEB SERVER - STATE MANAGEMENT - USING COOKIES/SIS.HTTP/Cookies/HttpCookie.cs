namespace SIS.HTTP.Cookies
{
    using System;
    using Contracts;
    public class HttpCookie : IHttpCookie
    {
        private const int HttpCookieDefaultExpirationDate = 3;

        public HttpCookie(string key, string value, int expiresInDays=HttpCookieDefaultExpirationDate)
        {
            this.Key = key;
            this.Value = value;
            this.Expires = DateTime.UtcNow.AddDays(expiresInDays);
        }

        public HttpCookie(string key, string value,bool isNew, int expiresInDays = HttpCookieDefaultExpirationDate)
            :this(key,value,expiresInDays)
        {
            this.IsNew = isNew;
        }

        public string Key { get; }

        public string Value { get; }

        public DateTime Expires { get; }

        public bool IsNew { get; }

        public override string ToString()
        {
            return $"{this.Key}={this.Value}; Expires={this.Expires.ToLongTimeString()}";
        }
    }
}
