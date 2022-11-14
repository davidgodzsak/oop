using System;
using Ora2_Csharp.Tamagotchi.Domain;
using Ora2_Csharp.Util;

namespace Ora2_Csharp.Tamagotchi.Animal
{
    public abstract class Animal : IAnimal
    {
        protected int mood;
        protected Position position;
        protected float energy;

        protected Animal(Mood mood, Position position, float energy)
        {
            switch (mood)
            {
                case Mood.Good: this.mood = 100; break;
                case Mood.Neutral: this.mood = 50; break;
                case Mood.Bad: this.mood = 10; break;
            }

            this.position = position;
            this.energy = energy;
        }

        public Position Position { get => position; }
        public float Energy { get => energy; }
        public Mood Mood { get => mood > 30 ? mood > 70 ? Mood.Good : Mood.Neutral : Mood.Bad; }

        public Position Move(Position delta)
        {
            position += delta;
            energy -= (delta.x + delta.y) / 2;
            return Position;
        }
        public float Feed(float food) => energy += food;

        public float Sleep(float time) => energy += time;

        public virtual float Aging(float minutes) => energy -= minutes;

        public void Neglected() => mood--;
    }
}

