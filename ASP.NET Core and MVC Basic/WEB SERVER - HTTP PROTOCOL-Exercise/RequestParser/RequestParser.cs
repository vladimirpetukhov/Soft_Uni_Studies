namespace RequestParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    public class RequestParser
    {
        public static void Main()
        {
            var endPointRoutes = new Dictionary<string, HashSet<string>>();

            var input = string.Empty;
            while (!((input = Console.ReadLine()).Equals("END")))
            {
                var splitInput = input.Split('/', StringSplitOptions.RemoveEmptyEntries);
                var endPoint = splitInput[0];
                var httpMethod = splitInput[1];

                if (!endPointRoutes.ContainsKey(httpMethod))
                {
                    endPointRoutes.Add(httpMethod, new HashSet<string>());
                }
                endPointRoutes[httpMethod].Add(endPoint);

                Console.WriteLine(string.Join(", ", splitInput));
            }

            var request = Console.ReadLine()
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var requestMethod = request[0];
            var requestRoute = request[1].Trim('/');
            var requestHttp = request[2];

            var httpResponse = string.Empty;

            if (endPointRoutes.ContainsKey(requestMethod))
            {
                var endpoint = endPointRoutes[requestMethod]
                    .FirstOrDefault(r => r == requestRoute);

                if (endpoint != null)
                {
                    httpResponse = $"{requestHttp.ToUpper()} {(int)HttpStatusCode.OK} {HttpStatusCode.OK} {Environment.NewLine}" +
                    $"Content-Lenght: {HttpStatusCode.OK.ToString().Length} {Environment.NewLine}" +
                    $"Content-Type: text/plain {Environment.NewLine}{Environment.NewLine}" +
                    $"{HttpStatusCode.OK}";
                }
                else
                {
                    httpResponse = $"{requestHttp.ToUpper()} {(int)HttpStatusCode.NotFound} {HttpStatusCode.NotFound} {Environment.NewLine}" +
                    $"Content-Lenght: {HttpStatusCode.NotFound.ToString().Length} {Environment.NewLine}" +
                    $"Content-Type: text/plain {Environment.NewLine}{Environment.NewLine}" +
                    $"{HttpStatusCode.NotFound}";
                }

            }

            Console.WriteLine(httpResponse);
        }
    }
}
