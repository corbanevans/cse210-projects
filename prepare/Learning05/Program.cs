using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a list of Shape objects
        List<Shape> shapes = new List<Shape>
        {
            new Square("Red", 4),
            new Rectangle("Blue", 5, 3),
            new Circle("Green", 2.5)
        };

        // Iterate through each shape and display details
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}, Area: {shape.GetArea():F2}");
        }
    }
}
