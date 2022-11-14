using System;
using Ora2_Csharp.Util;
using Ora2_Csharp.Tamagotchi;
using Ora2_Csharp.Tamagotchi.Domain;

namespace Ora2_Csharp.Tamagotchi.Animal
{
    public class Cat : Animal, IFeline, IPlayful
    {
        public readonly string Name;

        public Cat(string name) : this(name, new(0, 0), 50, Mood.Neutral)
        { }

        private Cat(string name, Position position, int energy, Mood mood) : base(mood, position, energy)
        {
            this.Name = name;
        }

        public void Meow()
        {
            Console.WriteLine("Meowww!");
        }

        public void Purr()
        {
            Console.WriteLine("Purrrrr!");
        }

        public void PlayWithForMinutes(int minutes)
        {
            energy -= minutes / 2;

            mood += minutes / 5;
        }
    }
}

