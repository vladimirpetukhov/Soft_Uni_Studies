


namespace ForeignLanguages
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string country = Console.ReadLine();

            string language = string.Empty;
            switch (country)
            {
                case "USA":
                case "England":
                    language = "English";
                    break;
                case "Spain":
                case "Argentina ":
                case "Mexico":
                    language = "Spanish ";
                    break;
                default:
                    language = "unknown";
                    break;
            }

            Console.WriteLine(language);
        }
    }
}
