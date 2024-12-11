namespace HeimdalHomework.Entities
{
    public class Circle : Shape
    {
        private double Radius { get; set; }

        public Circle(Location location, double radius)
            : base(location)
        {
            Radius = radius;
        }

        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"Circle at {Location.ToString()} with radius {Radius}";
        }
    }
}
