namespace HeimdalHomework.Entities
{
    public abstract class Shape
    {
        public Location Location { get; set; }

        public Shape(Location location)
        {
            Location = location;
        }

        public abstract double Area();
        public abstract double Perimeter();

        public override string ToString()
        {
            return $"Shape at {Location.ToString()}";
        }
    }
}
