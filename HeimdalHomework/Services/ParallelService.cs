using HeimdalHomework.Entities;

namespace HeimdalHomework.Services
{
    public class ParallelService
    {
        private readonly ShapeService _shapeService;

        public ParallelService()
        {
            _shapeService = new ShapeService();
        }

        // Optimized method to calculate the sum of circle perimeters using parallelism -> only using 2 threads
        public double GetSumOfCirclesParallel(List<Shape> shapes)
        {
            int mid = shapes.Count / 2;

            // Split the list into two parts
            var task1 = Task.Run(() => _shapeService.GetSumOfCircles(shapes.GetRange(0, mid)));
            var task2 = Task.Run(() => _shapeService.GetSumOfCircles(shapes.GetRange(mid, shapes.Count - mid)));

            Task.WaitAll(task1, task2);

            return task1.Result + task2.Result;
        }
    }
}
