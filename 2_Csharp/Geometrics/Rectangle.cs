using System;
using Ora2_Csharp.Util;

namespace Ora2_Csharp.Geometrics
{
    public class Rectangle
    {
        public Position Center { get; init; }
        public float Width { get; init; }
        public float Height { get; init; }
        // todo add rotation

        public Rectangle()
        {
        }

        public Rectangle(Position center, float width, float height) {
            this.Center = center;
            this.Width = width;
            this.Height = height;
        }

        public Rectangle(Position bottomLeft, Position topRight)
        {
            this.Width = topRight.X - bottomLeft.X;
            this.Height = bottomLeft.Y -  topRight.Y;
            this.Center = new Position(bottomLeft.X + Width / 2, bottomLeft.Y - Height / 2);
        }

        public Rectangle(Position first, Position second, Position third)
        {
            // todo check if it's a rectangle (third point coincident to one of the other?)
            //this.Width = 
            //this.Height =
            //this.Center = 
        }

        public Position TopLeftCorner { get => Center - new Position(Width / 2, Height / 2); }
        public Position BottomLeftCorner { get => Center + new Position(- Width / 2, Height / 2); }
        public Position TopRightCorner { get => Center + new Position(Width / 2, -Height / 2); }
        public Position BottomRightCorner { get => Center + new Position(Width / 2, Height / 2); }
    }
}

