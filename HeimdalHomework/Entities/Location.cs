namespace HeimdalHomework.Entities
{
    public class Location
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Location(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
