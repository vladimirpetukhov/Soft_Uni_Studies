


namespace AddTwoNumbers
{
    using System;
   public class Program
    {
        public static void Main()
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            int sum = number1 + number2;
            Console.WriteLine($"{number1} + {number2} = {sum}");
        }
    }
}
