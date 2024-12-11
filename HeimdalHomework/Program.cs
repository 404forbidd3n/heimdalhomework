using HeimdalHomework.Entities;
using HeimdalHomework.Services;

namespace ShapeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Clock logic
            Console.WriteLine("Enter hour:");
            int hour = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter minute:");
            int minute = int.Parse(Console.ReadLine());

            ClockAngleService clockAngleService = new ClockAngleService();
            double angle = clockAngleService.GetClockAngle(hour, minute);

            Console.WriteLine($"The angle between the clock hands is: {angle} degrees\n");

            // Call the shape display logic
            DisplayShapesAndCalculatePerimeters();
        }

        static void DisplayShapesAndCalculatePerimeters()
        {
            // Instantiate services
            ShapeService shapeService = new ShapeService();
            ParallelService parallelService = new ParallelService();

            // Generate shapes
            List<Shape> shapes = shapeService.GetShapes(10);

            // Display shapes
            foreach (var shape in shapes)
            {
                Console.WriteLine($"Shape: {shape} - Perimeter: {shape.Perimeter()}");
            }

            // Calculate sum of circle perimeters (sequential)
            double sumOfCircles = shapeService.GetSumOfCircles(shapes);
            Console.WriteLine($"Sum of Circle Perimeters: {sumOfCircles}");

            // Calculate sum of circle perimeters (parallel)
            double sumOfCirclesParallel = parallelService.GetSumOfCirclesParallel(shapes);
            Console.WriteLine($"Sum of Circle Perimeters (Parallel): {sumOfCirclesParallel}");
        }
    }
}
