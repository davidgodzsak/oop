using System;
using Ora3_HaziFeladat.Geometrics;

namespace Ora3_HaziFeladat
{
    public class App
    {
        public static void Main()
        {
            /* Feladatok
             * 1. Hozd létre a Basics mappában (namespaceben) a következőket
             *   - Point(X,Y), 3DPoint(X,Y,Z)
             *   - Line(Point A, Point B)
             * 2. Hozz létre tetszőleges alakokat (Square a példa)
             *   - Square, Rectangle, Triangle, Ngon (szabályos sokszög), Polygon
             *   - Cube, Cylinder, Sphere, etc.
             * 3. Ezekhez többféle konstruktor
             *   - Hibakezeléssel
             * 4. Számítások
             *   - Térfogat, Kerület, Terület, stb.
             * 5. Getterek az egyes csúcsokhoz, pontokhoz, amiket nem adtunk meg konstruktorban
             * 6. Listákat hozz létre alakzatokból 
             *   - Különböző paraméterekkel
             *   - Írj LINQ lekérdezéseket a listához
             * 7. Hozz létre hibás testeket és ezeket használd
             */


            // A Point osztály még nincs megírva (te feladatod) ezért hibásnak jelöli a fordító
            // Vigyázz a System.Drawing namespaceben is van egy Point osztály, nekünk NEM az kell, hane ma saját.

            var a = new Square(new Point(0, 0), new Point(10, 10));
        }
    }
}

