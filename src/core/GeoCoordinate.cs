using System;

namespace TurtleRoute
{
    public readonly struct GeoCoordinate(double latitude, double longitude) : IEquatable<GeoCoordinate>
    {
        public double Latitude { get; } = latitude;
        public double Longitude { get; } = longitude;

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