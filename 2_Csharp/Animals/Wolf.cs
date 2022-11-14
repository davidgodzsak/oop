using System;
using Ora2_Csharp.Util;
using Ora2_Csharp.Animal.Domain;

namespace Ora2_Csharp.Animal
{
    public class Wolf : Animal, ICanine
    {
        public Wolf() : this(new(0, 0), 80, Mood.Bad)
        { }

        private Wolf(Position position, int energy, Mood mood) : base(mood, position, energy)
        { }

        public void Bark()
        {
            Console.WriteLine("Awoooooo!");
            mood++;
        }
    }
}
