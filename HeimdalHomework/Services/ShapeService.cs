using HeimdalHomework.Entities;

namespace HeimdalHomework.Services
{
    public class ShapeService
    {
        // Method to create a collection of shapes
        public List<Shape> GetShapes(int n)
        {
            List<Shape> shapes = new List<Shape>();
            Random random = new Random();

            for (int i = 1; i <= n; i++)
            {
                double perimeter = i; // Perimeter must match the index

                if (random.Next(2) == 0)
                {
                    // Create a circle
                    double radius = perimeter / (2 * Math.PI);
                    shapes.Add(new Circle(new Location(0, 0), radius));
                }
                else
                {
                    // Create a rectangle
                    double side1 = random.NextDouble() * perimeter / 2;
                    double side2 = (perimeter - 2 * side1) / 2;
                    shapes.Add(new Rectangle(new Location(0, 0), side1, side2));
                }
            }

            return shapes;
        }

        // Method to calculate the sum of circle perimeters
        public double GetSumOfCircles(List<Shape> shapes)
        {
            double sum = 0;
            foreach (var shape in shapes)
            {
                if (shape is Circle circle)
                {
                    sum += circle.Perimeter();
                }
            }
            return sum;
        }
    }
}
