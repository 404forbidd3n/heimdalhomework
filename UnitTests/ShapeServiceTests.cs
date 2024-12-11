using HeimdalHomework.Entities;
using HeimdalHomework.Services;

namespace HeimdalHomework.Tests
{
    [TestClass]
    public class ShapeServiceTests
    {
        private ShapeService _shapeService;

        [TestInitialize]
        public void Setup()
        {
            _shapeService = new ShapeService();
        }

        [TestMethod]
        public void Circle_Area_Calculation_IsCorrect()
        {
            // Arrange
            var location = new Location(0, 0);
            var radius = 5.0;
            var circle = new Circle(location, radius);

            // Act
            double area = circle.Area();

            // Assert
            Assert.AreEqual(Math.PI * radius * radius, area, 0.00001);
        }

        [TestMethod]
        public void Rectangle_Perimeter_Calculation_IsCorrect()
        {
            // Arrange
            var location = new Location(0, 0);
            var side1 = 4.0;
            var side2 = 6.0;
            var rectangle = new Rectangle(location, side1, side2);

            // Act
            double perimeter = rectangle.Perimeter();

            // Assert
            Assert.AreEqual(2 * (side1 + side2), perimeter, 0.00001);
        }

        [TestMethod]
        public void GetShapes_Returns_CorrectNumberOfShapes()
        {
            // Arrange
            int n = 10;

            // Act
            var shapes = _shapeService.GetShapes(n);

            // Assert
            Assert.AreEqual(n, shapes.Count);
        }

        [TestMethod]
        public void GetShapes_Perimeters_Match_Indexes()
        {
            // Arrange
            int n = 5;

            // Act
            var shapes = _shapeService.GetShapes(n);

            // Assert
            for (int i = 0; i < n; i++)
            {
                Assert.AreEqual(i + 1, shapes[i].Perimeter(), 0.00001);
            }
        }

        [TestMethod]
        public void GetSumOfCircles_Returns_CorrectSum()
        {
            // Arrange
            var shapes = new List<Shape>
            {
                new Circle(new Location(0, 0), 1), // Perimeter = 2π
                new Rectangle(new Location(0, 0), 2, 3), // Perimeter = 10
                new Circle(new Location(0, 0), 2), // Perimeter = 4π
            };

            // Act
            double sum = _shapeService.GetSumOfCircles(shapes);

            // Assert
            Assert.AreEqual(2 * Math.PI + 4 * Math.PI, sum, 0.00001);
        }
    }
}
