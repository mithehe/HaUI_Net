using System;

namespace Circle
{
    class Circle
    {
        public double Radius { get; set; }

        public Circle()
        {
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Area()
        {
            return Math.PI * Radius * Radius;

        }

        public double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public static void Main(string[] args)
        {
            Circle c = new Circle();
            Console.Write("Enter the radius of the circle: ");
            c.Radius = double.Parse(Console.ReadLine());
            Console.WriteLine($"Area of the circle: {c.Area():F2}");
            Console.WriteLine($"Perimeter of the circle: {c.Perimeter():F2}");
        }
    }
}
