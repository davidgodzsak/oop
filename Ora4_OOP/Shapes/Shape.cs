using System;
namespace Ora4_OOP.Shapes
{
    public abstract class Shape
    {
        public Point Center { get; init; }
        public abstract float Area();
    }
}
