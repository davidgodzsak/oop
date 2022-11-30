using System;
namespace Ora4_OOP.Shapes
{
    public record class Point(float X, float Y)
    {
        public static Point operator +(Point a, Point b) => new(a.X + b.X, a.Y + b.Y);
        public static Point operator -(Point a) => new(-a.Y, -a.Y);
        public static Point operator -(Point a, Point b) => a + -b;
    }
}
