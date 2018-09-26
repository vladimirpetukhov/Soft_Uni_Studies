namespace ValidateUrl
{
    using System;
    using System.Net;
    using System.Text;

    public class UrlValidator
    {
        public static void Main()
        {
            var sb = new StringBuilder();
            var service = new Services();

            var urlString = Console.ReadLine();

            bool isValid = service.ValidateUrl(urlString);

            if (!isValid)
            {
                sb.AppendLine("Invalid url!");
            }
            else
            {
                var url = WebUtility.UrlDecode(urlString);

                var decoded = new Uri(url);

                service = new Services(decoded);

                sb.AppendLine(service.GetProtocol());
                sb.AppendLine(service.GetHost());
                sb.AppendLine(service.GetPort());
                sb.AppendLine(service.GetPath());

                if (!string.IsNullOrEmpty(service.GetQuery()))
                {
                    sb.AppendLine(service.GetQuery());
                }

                if (!string.IsNullOrEmpty(service.GetFragment()))
                {
                    sb.AppendLine(service.GetFragment());
                }

            }

            Console.WriteLine(sb.ToString().Trim());

        }        

    }
}
