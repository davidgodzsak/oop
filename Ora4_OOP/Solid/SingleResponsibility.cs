using System;
using Ora4_OOP.Shapes;

namespace Ora4_OOP.Solid
{
    [Obsolete("Single Responsibility - Rossz, nem jó így csinálni")]
    public class AreaCalculatorBad
    {
        float Calculate(Shape shape) => shape.Area();

        void Print(Shape shape)
        {
            Console.WriteLine($"This shape has an area of {shape.Area()}");
        }
    }

    public class AreaCalculator
    {
        float Calculate(Shape shape) => shape.Area();
    }

    public class ShapePrinter
    {
        void Print(Shape shape)
        {
            Console.WriteLine($"This shape has an area of {shape.Area()}");
        }
    }
}

