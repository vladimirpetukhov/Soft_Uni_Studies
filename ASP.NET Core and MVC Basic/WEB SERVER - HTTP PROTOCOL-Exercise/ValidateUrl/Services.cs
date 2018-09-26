using System;
namespace ValidateUrl
{
    public class Services
    {
        private Uri uri;

        public Services()
        {

        }
        public Services(Uri uri)
        {
            this.uri = uri;
        }
        internal string GetProtocol()
        {
            return this.uri.Scheme;
        }

        internal string GetPort()
        {
            var protocol = GetProtocol();
            var port = this.uri.Port.ToString();

            if (string.IsNullOrEmpty(port))
            {
                if (protocol.Equals("http"))
                {
                    port = "80";
                }

                if (protocol.Equals("https"))
                {
                    port = "443";
                }
            }
            return port;
        }

        internal string GetHost()
        {
            return this.uri.Host;
        }

        internal string GetPath()
        {
            var path = string.Empty;

            var pathQuery = this.uri.PathAndQuery;
            
            if(pathQuery!="/")
            {
                var pathLenght = pathQuery.IndexOf('?');
                path = pathQuery.Substring(0, pathLenght);
            }
            else
            {
                path = pathQuery;
            }

            return path;
        }

        internal string GetQuery()
        {
            var result = string.Empty;

            var query = this.uri.Query;

            if (query != "")
            {
                result = query.Substring(1, query.Length - 1);
            }

            return result;
        }

        internal string GetFragment()
        {
            var result = string.Empty;

            var fragment= this.uri.Fragment;

            if (fragment != "")
            {
                result = fragment.Substring(1, fragment.Length - 1);
            }

            return result;
        }

        internal bool ValidateUrl(string uri)
        {
            if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            { return false; }
            Uri tmp;
            if (!Uri.TryCreate(uri, UriKind.Absolute, out tmp))
            { return false; }
            return tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps;
        }

    }
}
