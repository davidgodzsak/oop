using System;
using Ora2_Csharp.Tamagotchi.Animal;
using Ora2_Csharp.Tamagotchi.Domain;
using Ora2_Csharp.Util;

namespace Ora2_Csharp.Tamagotchi
{
    public class TamagotchiGameEngine
    {
        private long time = 0;

        public void Run()
        {
            Console.WriteLine("Hello! Welcome to the Tamagotchi World!");
            var animal = SelectAnimal();

            ConsoleKeyInfo key;
            do
            {
                Console.WriteLine();
                GameLogic(animal);
                Step();
                Console.WriteLine("Press ESC to leave, other to continue!");
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Escape);
        }

        private IAnimal SelectAnimal()
        {
            Console.WriteLine("Please select your pet!");

            IAnimal? animal = null;
            do
            {
                Console.WriteLine("D) dog");
                Console.WriteLine("C) cat");
                Console.WriteLine("W) wolf");
                Console.Write("Your pet: ");

                switch (Console.ReadLine())
                {
                    case "D":
                        Console.WriteLine("What should we name your doggo? ");
                        Console.Write("My pet is called: ");
                        string dogName = Console.ReadLine() ?? "Blöki";

                        animal = new Dog(dogName);
                        break;
                    case "C":
                        Console.WriteLine("What should we name your kitty? ");
                        Console.Write("My pet is called: ");
                        string catName = Console.ReadLine() ?? "Cirmos";

                        animal = new Cat(catName);
                        break;
                    case "W":
                        animal = new Wolf();
                        break;
                    default:
                        animal = null;
                        break;

                }
            } while (animal == null);

            return animal;
        }

        private void Step() => time++;

        private void GameLogic(IAnimal animal)
        {
            Console.WriteLine($"Pet: what should we do?");

            Console.WriteLine("F) Feed\nS) Sleep\nM) Move");
            if (animal is IPlayful) Console.WriteLine("P) Play");
            if (animal is IFeline) Console.WriteLine("W) Meow\nR) Purr");
            if (animal is ICanine) Console.WriteLine("B) Bark");

            Console.Write("You: ");
            var whatToDo = Console.ReadLine();

            switch (whatToDo)
            {
                case "F":
                    animal.Feed(1);
                    break;
                case "S":
                    animal.Sleep(1);
                    break;
                case "M":
                    Console.WriteLine("Where should we go?\nU) Up\nD) Down\nL) Left\nR) Right");
                    var key = Console.ReadLine();
                    Position direction;
                    switch (key)
                    {
                        case "U": direction = new Position(0, -1); break;
                        case "D": direction = new Position(0, -1); break;
                        case "L": direction = new Position(0, -1); break;
                        case "R": direction = new Position(0, -1); break;
                        default: direction = new Position(0, 0); break;
                    }
                    animal.Move(direction);
                    break;
                case "P":
                    if (animal is IPlayful) ((IPlayful)animal).PlayWithForMinutes(1);
                    break;
                case "W":
                    if (animal is IFeline) ((IFeline)animal).Meow();
                    break;
                case "R":
                    if (animal is IFeline) ((IFeline)animal).Purr();
                    break;
                case "B":
                    if (animal is ICanine) ((ICanine)animal).Bark();
                    break;
            }

            if (time % 5 == 0)
            {
                animal.Aging(1);
            }

            if (time % 15 == 0)
            {
                animal.Neglected();
            }

            Console.WriteLine($"Your pet is at ({animal.Position.x},{animal.Position.y}), currently {animal.Mood} and has energy of {animal.Energy}");
        }
    }
}