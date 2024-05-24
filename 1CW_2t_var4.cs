

using System.Drawing;

abstract class Shape
{
    public abstract double GetArea();
    public abstract double GetPerimeter();
    public abstract string GetName();
}

class Round : Shape
{
    private double radius;
    public double Radius { get { return radius; } }

    public Round(double Radius)
    {
        radius = Radius;
    }

    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }

    public override double GetPerimeter()
    {
        return 2 * Math.PI * radius;
    }
    public override string GetName()
    {
        return "Round";
    }
}

class Square : Shape
{
    private double side;
    public double Side { get { return side; } }
    public Square(double Side)
    {
        side = Side;
    }

    public override double GetArea()
    {
        return side * side;
    }

    public override double GetPerimeter()
    {
        return 4 * side;
    }
    public override string GetName()
    {
        return "Square";
    }
}

class Triangle : Shape
{
    private double side1, side2, side3;
    public double Side1 { get { return side1; } }
    public double Side2 { get { return side2; } }
    public double Side3 { get { return side3; } }
    public Triangle(double Side1, double Side2, double Side3)
    {
        side1 = Side1;
        side2 = Side2;
        side3 = Side3;
    }
    
    public override double GetArea()
    {
        double p = (side1 + side2 + side3) / 2;
        return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
    }

    public override double GetPerimeter()
    {
        return side1 + side2 + side3;
    }
    public override string GetName()
    {
        return "Triangle";
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        Shape[] rounds =
        { new Round(3),
        new Round(5),
        new Round(2),
        new Round(4),
        new Round(1)
        };

        Shape[] squares =
        {
            new Square(4),
            new Square(2),
            new Square(3),
            new Square(1),
            new Square(5)
        };


        Shape[] triangles =
        {
            new Triangle(3, 4, 5),
            new Triangle(2, 2, 3),
            new Triangle(5, 6, 7),
            new Triangle(1, 2, 2),
            new Triangle(4, 4, 4)
        };
        BubbleSortByArea(rounds);
        BubbleSortByArea(squares);
        BubbleSortByArea(triangles);
        Console.WriteLine("Rounds sorted by area:");
        Console.WriteLine("Name\tPerimeter\tArea");
        foreach (var round in rounds)
        {
            Console.WriteLine($"{round.GetName()}\t{round.GetPerimeter()}\t{round.GetArea()}");
        }

        Console.WriteLine("\nSquares sorted by area:");
        Console.WriteLine("Name\tPerimeter\tArea");
        foreach (var square in squares)
        {
            Console.WriteLine($"{square.GetName()}\t{square.GetPerimeter()}\t{square.GetArea()}");
        }

        Console.WriteLine("\nTriangles sorted by area:");
        Console.WriteLine("Name\tPerimeter\tArea");
        foreach (var triangle in triangles)
        {
            Console.WriteLine($"{triangle.GetName()}\t{triangle.GetPerimeter()}\t{triangle.GetArea()}");
        }
    

        static void BubbleSortByArea(Shape[] shapes)
        {
            for (int i = 0; i < shapes.Length - 1; i++)
            {
                for (int j = 0; j < shapes.Length - 1 - i; j++)
                {
                    if (shapes[j].GetArea() < shapes[j + 1].GetArea())
                    {
                        Shape temp = shapes[j];
                        shapes[j] = shapes[j + 1];
                        shapes[j + 1] = temp;
                    }
                }
            }
        }



        Shape[] shapes =
        {
            new Round(3),
            new Round(5),
            new Round(2),
            new Round(4),
            new Round(1),
            new Square(4),
            new Square(2),
            new Square(3),
            new Square(1),
            new Square(5),
            new Triangle(3, 4, 5),
            new Triangle(2, 2, 3),
            new Triangle(5, 6, 7),
            new Triangle(1, 2, 2),
            new Triangle(4, 4, 4)
        };
        BubbleSortByArea(shapes);
        Console.WriteLine("Shapes sorted by area:");
        Console.WriteLine("Name\tPerimeter\tArea");
        foreach (var shape in shapes)
        {
            Console.WriteLine($"{shape.GetName()}\t{shape.GetPerimeter()}\t{shape.GetArea()}");
        }
        
    }
}


