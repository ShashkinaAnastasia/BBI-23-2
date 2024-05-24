using System.Text;

class Triangle
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
   public string typeOfTriangle()
    {
        if (side1 == side2)
            return "Равнобедренный";
        if (side1 == side2 & side2 == side3)
            return "Равностороннийй";
        else       
            return "Разносторонний";
          
    }
    
    public double GetArea()
    {
        double p = (side1 + side2 + side3) / 2;
        return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
    }
}

class Program
{
    static void Main(string[] args)
    {

        
        Triangle [] triangles =
        {
            new Triangle(3, 4, 5),
            new Triangle(2, 2, 3),
            new Triangle(5, 6, 7),
            new Triangle(1, 2, 2),
            new Triangle(4, 4, 4),
        };
        
        BubbleSortByArea(triangles);
        
        Console.WriteLine("Triangles sorted by area:");
        
        foreach (var triangle in triangles)
        {
            Console.WriteLine($"{triangle.GetArea()}\t{triangle.typeOfTriangle()}");
        }


        static void BubbleSortByArea(Triangle [] triangles)
        {
            for (int i = 0; i < triangles.Length - 1; i++)
            {
                for (int j = 0; j < triangles.Length - 1 - i; j++)
                {
                    if (triangles[j].GetArea() < triangles[j + 1].GetArea())
                    {
                        Triangle temp = triangles[j];
                        triangles[j] = triangles[j + 1];
                        triangles[j + 1] = temp;
                    }
                }
            }
        }       
    }
}
