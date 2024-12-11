namespace HeimdalHomework.Entities
{
    public class Rectangle : Shape
    {
        private double Side1 { get; set; }
        private double Side2 { get; set; }

        public Rectangle(Location location, double side1, double side2)
            : base(location)
        {
            Side1 = side1;
            Side2 = side2;
        }

        public override double Area()
        {
            return Side1 * Side2;
        }

        public override double Perimeter()
        {
            return 2 * (Side1 + Side2);
        }

        public override string ToString()
        {
            return $"Rectangle at {Location.ToString()} with sides {Side1} and {Side2}";
        }
    }
}
