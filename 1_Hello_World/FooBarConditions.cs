using System;
using static System.Net.Mime.MediaTypeNames;

namespace Ora1_Hello_World
{
    public class FooBarConditions
    {
        public static void If(string[] args)
        {
            Console.Write("Adj egy számot: ");
            var input = Console.ReadLine();
            var number = Convert.ToInt32(input);

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

        public static void Switch(string[] args)
        {
            
            Console.Write("Adj egy számot: ");
            var input = Console.ReadLine();
            var number = Convert.ToInt32(input);

            switch(number)
            {
                case 3:
                    Console.WriteLine("Foo");
                    break;
                case 5:
                    Console.WriteLine("Bar");
                    break;
                case 15:
                    Console.WriteLine("Baz");
                    break;
                default:
                    Console.WriteLine(number);
                    break;
            }

        }

        public static void Ternary(string[] args)
        {

            Console.Write("Adj egy számot: ");
            var input = Console.ReadLine();
            var number = Convert.ToInt32(input);

            var text = number == 42 ? "Always carry a towel!" : "Meh";

            Console.WriteLine(text);
        }
    }
}