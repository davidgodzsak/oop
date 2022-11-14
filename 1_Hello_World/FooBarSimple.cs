using System;

namespace Ora1_Hello_World
{
    public class FooBarSimple
    {
        public static void Run(string[] args)
        {
            Console.Write("Adj egy számot: ");
            string input = Console.ReadLine();
            int number = Convert.ToInt32(input);

            if (number % 15 == 0)
            {
                Console.WriteLine("Baz");
            }
            else if (number % 5 == 0)
            {
                Console.WriteLine("Bar");
            }
            else if (number % 3 == 0)
            {
                Console.WriteLine("Foo");
            }
            else
            {
                Console.WriteLine(number);
            }
            Console.Read();
        }
    }
}