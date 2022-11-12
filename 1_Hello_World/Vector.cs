using System;

namespace _1_Hello_World
{
    public class Vector
    {
        public static void SumBasic(string[] args)
        {
            int[] vec = { 1, 2, 3 };

            var sum = 0;
            foreach(var item in vec)
            {
                //sum = sum + item
                sum += item;
            }

            Console.WriteLine($"Összeg: {sum}");
        }

        public static void SumAdvanced(string[] args)
        {
            int[] vec = { 1, 2, 3 };

            var sum = vec.Sum();
            Console.WriteLine($"Összeg: {sum}");
        }


        public static void AddBasic(string[] args)
        {
            int[] vec1 = { 1, 2, 3 };
            int[] vec2 = { 2, 4, 6 };

            int[] vec3 = new int[3];
            for(var i = 0; i < vec1.Length; i++)
            {
                vec3[i] = vec1[i] + vec2[i];
            }

            Console.WriteLine("A vektor értékei: {0} {1} {2}",vec3[0], vec3[1], vec3[2]);
        }

        public static void AddAdvanced(string[] args)
        {
            int[] vec1 = { 1, 2, 3 };
            int[] vec2 = { 2, 4, 6 };

            var vec3 = vec1.Zip(vec2, (a, b) => a + b);
        }
    }
}