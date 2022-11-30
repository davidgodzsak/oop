using System;
namespace Ora4_OOP.Shapes
{
    public class Rectangle : Shape
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public Rectangle(float width, float height, Point center)
        {
            this.Center = center;
            this.Width = width;
            this.Height = height;
        }

        public override float Area() => Width * Height;
    };
}

