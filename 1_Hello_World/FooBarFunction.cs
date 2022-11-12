using System;

namespace _1_Hello_World
{
    public class FooBarFunction
    {
        public static void FooBar(string[] args)
        {
            Console.Write("Adj egy számot: ");
            int from = ReadNumber();
            Console.Write("Adj egy számot: ");
            var to = ReadNumber();

            for (int i = from; i < to; i++)
            {
                Console.Write(i);
                WhenMultipleOf(i, 15, "Baz");
                WhenMultipleOf(i, 5, "Bar");
                WhenMultipleOf(i, 3, "Foo");
            }
            Console.Read();
        }

        private static void WhenMultipleOf(int number, int divider, string text)
        {
            if(number % divider == 0) Console.WriteLine(text);
        }

        private static int ReadNumber()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}