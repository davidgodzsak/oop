using System;
namespace Ora4_OOP.Shapes
{
    public class Square: Rectangle
    {
        public Square(float size, Point center) : base(size, size, center)
        { }

        public override float Area() => Width * Height;
    };
}

