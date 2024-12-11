using HeimdalHomework.Services;

namespace HeimdalHomework.Tests
{
    [TestClass]
    public class ClockAngleServiceTests
    {
        private ClockAngleService _clockAngleService;

        [TestInitialize]
        public void Setup()
        {
            _clockAngleService = new ClockAngleService();
        }

        [TestMethod]
        [DataRow(3, 0, 90)] // 3:00 should return 90 degrees
        [DataRow(6, 0, 180)] // 6:00 should return 180 degrees
        [DataRow(9, 0, 90)] // 9:00 should return 90 degrees
        [DataRow(12, 0, 0)] // 12:00 should return 0 degrees
        [DataRow(10, 10, 115)] // 10:10 should return 115 degrees
        [DataRow(3, 15, 7.5)] // 3:15 should return 7.5 degrees
        public void GetClockAngle_ValidInputs_ReturnsCorrectAngle(int hour, int minute, double expectedAngle)
        {
            // Act
            double actualAngle = _clockAngleService.GetClockAngle(hour, minute);

            // Assert
            Assert.AreEqual(expectedAngle, actualAngle, 0.1, "The angle calculated is not as expected."); // Allow small tolerance for floating-point comparison
        }
    }
}
