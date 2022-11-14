using System;
namespace Ora2_Csharp.Util
{
    public record class Position(int x, int y)
    {
        public static Position operator +(Position a, Position b) => new(a.x + b.x, a.y + b.y);
        public static Position operator -(Position a) => new(-a.x, -a.y);
        public static Position operator -(Position a, Position b) => a + -b;
    }
}
