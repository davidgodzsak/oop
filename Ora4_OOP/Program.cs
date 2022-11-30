
using Ora4_OOP.Shapes;


// polymorphism
List<Shape> shapes = new List<Shape>
{
    new Rectangle(10, 3, new (0, 1)),
    new Square(3, new (10, 8)),
    new Circle{ Center= new (19, 17), Radius = 0.5f }
};


shapes.Sum(shape => shape.Area());