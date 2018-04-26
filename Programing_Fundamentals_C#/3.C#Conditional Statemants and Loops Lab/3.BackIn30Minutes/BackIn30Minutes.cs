


namespace BackIn30Minutes
{
    using System;
    public class Program
    {
        public static void Main()
        {
            string hours = Console.ReadLine();
            string minutes = Console.ReadLine();

            string time = string.Format($"{hours}:{minutes}");
            string format = "H:mm";
            DateTime myDateTime = DateTime.ParseExact(time, format,
                System.Globalization.CultureInfo.InvariantCulture);

            myDateTime = myDateTime.AddMinutes(30);
            Console.WriteLine(myDateTime.ToString("H:mm"));
        }
    }
}
