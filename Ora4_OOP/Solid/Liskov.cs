using System;
using Ora4_OOP.Shapes;

namespace Ora4_OOP.Solid
{
    [Obsolete("LiskovSubstitution - Rossz, nem jó így csinálni")]
    public class SquareFactory
    {
        public static void Main()
        {
            var a = new Square(20, new(0, 0));
            Rectangle b = a;

            b.Width = 10; // utófeltétel sérül, megváltoztatja a Height-ot
            b.Height = 10; // utófeltétel sérül, megváltoztatja a Width-et
        }
    }


    // másik rossz
    public class Bird
    {
        public void fly() { }
    }
    public class Duck : Bird { }
    public class Penguin : Bird { }


    //jó megoldás
    public class Bird2 { }
    public class FlyingBirds2 : Bird2
    {
        public void fly() { }
    }
    public class Duck2 : FlyingBirds2 { }
    public class Penguin2 : Bird2 { }

}
