using System;
using Ora2_Csharp.Util;
using Ora2_Csharp.Animal.Domain;

namespace Ora2_Csharp.Animal
{
    public class Dog : Animal, ICanine, IPlayful
    {
        private readonly string Name;

        public Dog(string name) : this(name, new(0, 0), 60, Mood.Good)
        { }

        private Dog(string name, Position position, int energy, Mood mood) : base(mood, position, energy)
        {
            this.Name = name;
        }

        public void Bark()
        {
            Console.WriteLine("Woof, woof!");
        }

        public void PlayWithForMinutes(int minutes)
        {
            energy -= minutes / 2;

            mood += minutes / 3;
        }

        override public float Aging(float minutes) => energy -= minutes / 2;
    }
}
