using HeimdalHomework.Entities;
using HeimdalHomework.Services;

namespace HeimdalHomework.Tests
{
    [TestClass]
    public class ParallelServiceTests
    {
        private ParallelService _parallelService;

        [TestInitialize]
        public void Setup()
        {
            _parallelService = new ParallelService();
        }

        [TestMethod]
        public void GetSumOfCirclesParallel_Returns_CorrectSum()
        {
            // Arrange
            var shapes = new List<Shape>
            {
                new Circle(new Location(0, 0), 1), // Perimeter = 2π
                new Rectangle(new Location(0, 0), 2, 3), // Perimeter = 10
                new Circle(new Location(0, 0), 2), // Perimeter = 4π
            };

            // Act
            double sum = _parallelService.GetSumOfCirclesParallel(shapes);

            // Assert
            Assert.AreEqual(2 * Math.PI + 4 * Math.PI, sum, 0.00001);
        }
    }
}
