using System;
using Ora2_Csharp.Util;

namespace Ora2_Csharp.Geometrics
{
    public class Square
    {
        public Position Center { get; set; }
        public float Size { get; init; }

        public Square()
        {
        }

        public Square(float size, Position center)
        {
            this.Center = center;
            this.Size = size;
        }

        public Square(Position bottomLeft, Position topRight)
        {
            if (topRight.X - bottomLeft.X != bottomLeft.Y - topRight.Y)
            {
                throw new ArgumentException("Not a square");
            }

            this.Size = topRight.X - bottomLeft.X;
            this.Center = new Position(bottomLeft.X + Size / 2, bottomLeft.Y - Size / 2);
        }

        public Position TopLeftCorner { get => Center - new Position(Size / 2, Size / 2); }
        public Position BottomLeftCorner { get => Center + new Position(-Size / 2, Size / 2); }
        public Position TopRightCorner { get => Center + new Position(Size / 2, -Size / 2); }
        public Position BottomRightCorner { get => Center + new Position(Size / 2, Size / 2); }

        public void Move(Position delta)
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

