namespace UrlDecode
{
    using System;
    using System.Net;

    public class UrlDecode
    {
        public static void Main()
        {
            var urlString = Console.ReadLine();

            var encoded = WebUtility.UrlDecode(urlString);

            Console.WriteLine(encoded);
        }
    }
}
