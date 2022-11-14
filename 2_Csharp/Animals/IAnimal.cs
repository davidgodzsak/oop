using System;
using Ora2_Csharp.Animal.Domain;
using Ora2_Csharp.Util;

namespace Ora2_Csharp.Animal
{
    public interface IAnimal
    {
        public Position Position { get; }
        public float Energy { get; }
        public Mood Mood { get; }

        public Position Move(Position delta);
        public float Feed(float energy);
        public float Sleep(float energy);
        public float Aging(float minutes);
        public void Neglected();
    }
}

