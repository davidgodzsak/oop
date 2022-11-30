using System;
namespace Ora4_OOP.Shapes
{
    [Obsolete("Open-Closed - Rossz, nem jó így csinálni")]
    public class AreaCalculatorBad
    {

        float Calculate(Shape shape)
        {
            if(shape is Circle)
            {
                var circle = shape as Circle;
                return MathF.Pow(circle.Radius, 2) * MathF.PI;
            } else if (shape is Rectangle)
            {
                var rectangle = shape as Rectangle;
                return rectangle.Width * rectangle.Height;
            } else
            {
                throw new ArgumentException("Shape not recognized");
            }
        }
    }

    public class AreaCalculator
    {
        float Calculate(Shape shape) => shape.Area();
    }
}

