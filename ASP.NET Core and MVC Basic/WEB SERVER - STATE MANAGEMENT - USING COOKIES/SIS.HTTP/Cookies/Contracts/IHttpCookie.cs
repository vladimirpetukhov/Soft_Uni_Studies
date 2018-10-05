namespace SIS.HTTP.Cookies.Contracts
{
    using System;
    public interface IHttpCookie
    {
        string Key { get; }
        string Value { get; }
        DateTime Expires { get; }
        bool IsNew { get; }
    }
}
