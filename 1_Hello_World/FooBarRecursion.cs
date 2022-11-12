using System;
using static System.Net.Mime.MediaTypeNames;

namespace _1_Hello_World
{
    public class FooBarRecursion
    {
        public static void FooBar(string[] args)
        {
            Console.Write("Adj egy számot: ");
            int from = ReadNumber();
            Console.Write("Adj egy számot: ");
            var to = ReadNumber();

            FooBarRecursive(from, to);
            Console.Read();
        }

        public static void FooBarRecursive(int i, int to)
        {
            if (i > to) return;

            if (i % 15 == 0)
            {
                Console.WriteLine("Baz");
            } else if (i % 5 == 0)
            {
                Console.WriteLine("Bar");
            } else if  (i % 3 == 0)
            {
                Console.WriteLine("Foo");
            } else
            {
                Console.WriteLine(i);
            }

            FooBarRecursive(i + 1, to);
        }


        private static int ReadNumber()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}