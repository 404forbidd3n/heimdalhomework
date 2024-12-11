namespace HeimdalHomework.Services
{
    public class ClockAngleService
    {
        public double GetClockAngle(int hour, int minute)
        {
            // Normalize the hour to the 12-hour format
            hour = hour % 12;

            // Calculate the positions of the hour and minute hands in degrees
            double hourHandPosition = (hour * 30) + (minute * 0.5); // Each hour = 30 degrees, each minute contributes 0.5 degree
            double minuteHandPosition = minute * 6; // Each minute = 6 degrees

            // Calculate the absolute angle between the two hands
            double angle = Math.Abs(hourHandPosition - minuteHandPosition);

            // The angle should be the smaller of the two possible angles
            return Math.Min(angle, 360 - angle);
        }
    }
}
