using System;
using Ora2_Csharp.Geometrics;
using Ora2_Csharp.LINQ;
using Ora2_Csharp.Tamagotchi;
using Ora2_Csharp.Util;

namespace Ora2_Csharp
{
    public class App
    {
        public static void Main()
        {
            // new TamagotchiGameEngine().Run();
            School.RunExample();

            // Testing square creation
            var a = new Square(new  Position(0, 0), new Position(10, 10));
            
        }
    }
}

