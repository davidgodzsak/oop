using System;
namespace Ora2_Csharp.Util
{
    public record class Position(float X, float Y)
    {
        public static Position operator +(Position a, Position b) => new(a.X + b.X, a.Y + b.Y);
        public static Position operator -(Position a) => new(-a.Y, -a.Y);
        public static Position operator -(Position a, Position b) => a + -b;
    }
}
