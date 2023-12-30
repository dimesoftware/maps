using System;

namespace TurtleRoute
{
    public readonly struct GeoCoordinate : IEquatable<GeoCoordinate>
    {
        public GeoCoordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; }
        public double Longitude { get; }

        public override string ToString()
            => $"{Latitude},{Longitude}";

        public override bool Equals(Object other)
            => other is GeoCoordinate coordinate && Equals(coordinate);

        public bool Equals(GeoCoordinate other)
            => Latitude == other.Latitude && Longitude == other.Longitude;

        public override int GetHashCode()
            => Latitude.GetHashCode() ^ Longitude.GetHashCode();
    }
}