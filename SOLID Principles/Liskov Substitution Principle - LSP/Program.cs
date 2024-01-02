/*
  * Liskov Substitution Principle Example:
    This C# code exemplifies a geometric shapes hierarchy adhering to the Liskov Substitution Principle (LSP). 
    The IShape interface defines common shape operations, and the AbstractShape class provides a base implementation with a color property. 
    Derived classes, Rectangle, Square, and Triangle, inherit and implement specific area, perimeter, and detail calculations, maintaining substitutability. 
    The ShapeManager class demonstrates polymorphism, allowing seamless handling of different shapes without specific type knowledge. 
    The Test class showcases LSP compliance by calculating and displaying areas, perimeters, and details of rectangles, squares, and triangles interchangeably.
  */

using System;

namespace LSP
{
    public interface IShape
    {
        int GetArea();
        int GetPerimeter();
        void GetColor();
        void PrintDetails();
    }

    public abstract class AbstractShape : IShape
    {
        public string Color { get; set; }
        public abstract int GetArea();

        public abstract int GetPerimeter();
        public abstract void GetColor();
        public abstract void PrintDetails();
    }

    public class Rectangle : AbstractShape
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public override int GetArea() => Width * Height;
        public override int GetPerimeter() => ((Width + Height) * 2);
        public override void GetColor() => Console.WriteLine($"Color : {Color}");
        public override void PrintDetails() => Console.WriteLine($"Rectangle with dimensions {Width}X{Height}");
    }

    public class Square : AbstractShape
    {
        public int SideLength { get; set; }

        public override int GetArea() => SideLength * SideLength;
        public override int GetPerimeter() => 4 * SideLength;

        public override void GetColor() => Console.WriteLine($"Color: {Color}");
        public override void PrintDetails() => Console.WriteLine($"Square with side length {SideLength}");
    }

    public class Triangle : AbstractShape
    {
        public int Base { get; set; }
        public int Height { get; set; }

        public override int GetArea() => (Height * Base) / 2;

        public override int GetPerimeter()
        {
            if (Base > 0 && Height > 0)
            {
                return Base + Height + (int)Math.Sqrt(Base * Base + Height * Height);
            }

            return -1;
        }

        public override void GetColor() => Console.WriteLine($"Color: {Color}");
        public override void PrintDetails() => Console.WriteLine($"Triangle with Base {Base} and Height {Height}");
    }

    public class ShapeManager
    {
        public void CalculateArea(IShape shape) => Console.WriteLine("Area: {0}", shape.GetArea());
        public void CalculatePerimeter(IShape shape) => Console.WriteLine("Perimeter: {0}", shape.GetPerimeter());

        public void DisplayShapeDetails(IShape shape)
        {
            shape.GetColor();
            shape.PrintDetails();
        }
    }

    public class Test
    {
        public static void Main(string[] args)
        {
            ShapeManager manager = new ShapeManager();
            Rectangle R = new Rectangle { Width = 5, Height = 3, Color = "LAL" };
            Square S = new Square{SideLength = 4,Color = "KALA"};
            Triangle T = new Triangle { Base = 6, Height = 8, Color = "NIL" };


            manager.CalculateArea(R);
            manager.CalculateArea(S);
            manager.CalculateArea(T);

            manager.CalculatePerimeter(R);
            manager.CalculatePerimeter(S);
            manager.CalculatePerimeter(T);

            manager.DisplayShapeDetails(R);
            manager.DisplayShapeDetails(S);
            manager.DisplayShapeDetails(T);
        }
    }
}