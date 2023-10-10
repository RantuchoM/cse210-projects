using System;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        Square square = new("green",3);
        
        Console.WriteLine(square.GetArea());
        Console.WriteLine(square.GetColor());

        Rectangle rectangle = new("red",4,5);

        Console.WriteLine(rectangle.GetArea());
        Console.WriteLine(rectangle.GetColor());

        Circle circle = new("yellow",5);

        Console.WriteLine(circle.GetArea());
        Console.WriteLine(circle.GetColor());

        List<Shape> shapes = new() { square,rectangle,circle};

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Area: {shape.GetArea():F2}");
            Console.WriteLine($"Color: {shape.GetColor()}");
        }
    }
}