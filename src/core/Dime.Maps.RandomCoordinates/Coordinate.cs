namespace Dime.Maps.RandomCoordinates
{
    public record Coordinate
    {
        public double Latitude { get; }
        public double Longitude { get; }

        public Coordinate(double latitude, double longitude) => (Latitude, Longitude) = (latitude, longitude);
    }
}