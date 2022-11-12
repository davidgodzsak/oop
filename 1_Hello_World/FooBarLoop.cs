using System;

namespace _1_Hello_World
{
    public class FooBarLoop
    {
        public static void For(string[] args)
        {
            Console.Write("Adj egy számot: ");
            var from = Convert.ToInt32(Console.ReadLine());
            Console.Write("Adj egy számot: ");
            var to = Convert.ToInt32(Console.ReadLine());

            for (int i = from; i < to; i++)
            {
                var number = i;

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
                } else
                {
                    Console.WriteLine(number);
                }
            }
            Console.Read();
        }

        public static void While(string[] args)
        {
            Console.Write("Adj egy számot: ");
            var from = Convert.ToInt32(Console.ReadLine());
            Console.Write("Adj még egy számot: ");
            var to = Convert.ToInt32(Console.ReadLine());

            var i = from;
            while (i <= to)
            {
                var number = i;

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

                i++;
            }
            Console.Read();
        }

        public static void DoWhile(string[] args)
        {
            Console.Write("Adj egy számot: ");
            var from = Convert.ToInt32(Console.ReadLine());
            Console.Write("Adj még egy számot: ");
            var to = Convert.ToInt32(Console.ReadLine());

            int i = from;

            do
            {
                var number = i;

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

                i++;
            } while (i <= to);
            Console.Read();
        }

        public static void Select(string[] args)
        {
            Console.Write("Adj egy számot: ");
            var from = Convert.ToInt32(Console.ReadLine());
            Console.Write("Adj még egy számot: ");
            var to = Convert.ToInt32(Console.ReadLine());


            Enumerable.Range(from, to)
            .Select(number =>
            {
                if (number % 15 == 0)
                {
                    return "Baz";
                }
                else if (number % 5 == 0)
                {
                    return "Bar";
                }
                else if (number % 3 == 0)
                {
                    return "Foo";
                }
                else
                {
                    return number.ToString();
                }
            })
            .ToList()
            .ForEach(text => Console.WriteLine(text));
        }
    }
}