using System;

namespace Ora3_HaziFeladat.Geometrics
{
    public class Square
    {
        public Point Center { get; set; }
        public float Size { get; init; }

        public Square()
        {
        }

        public Square(float size, Point center)
        {
            this.Center = center;
            this.Size = size;
        }

        public Square(Point bottomLeft, Point topRight)
        {
            if (topRight.X - bottomLeft.X != bottomLeft.Y - topRight.Y)
            {
                throw new ArgumentException("Not a square");
            }

            this.Size = topRight.X - bottomLeft.X;
            this.Center = new Point(bottomLeft.X + Size / 2, bottomLeft.Y - Size / 2);
        }

        public Point TopLeftCorner { get => Center - new Point(Size / 2, Size / 2); }
        public Point BottomLeftCorner { get => Center + new Point(-Size / 2, Size / 2); }
        public Point TopRightCorner { get => Center + new Point(Size / 2, -Size / 2); }
        public Point BottomRightCorner { get => Center + new Point(Size / 2, Size / 2); }

        public void Move(Point delta)
        {
            Center += delta;
        }

        // could be a property?
        public float CalculateArea()
        {
            return MathF.Pow(Size,2);
        }

        // could be a property?
        public float CalculatePerimeter()
        {
            return 4 * Size;
        }
    }

}

