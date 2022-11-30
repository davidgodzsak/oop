using System;
namespace Ora4_OOP.Shapes
{
    public class Circle : Shape {
        public float Radius { get; init; }

        public override float Area() => MathF.PI * Radius * Radius;
    };
}
