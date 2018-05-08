using System;

namespace Dime.Maps
{
    /// <summary>
    /// 
    /// </summary>
    public struct GeoCoordinate : IEquatable<GeoCoordinate>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public GeoCoordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; }
        public double Longitude { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => $"{Latitude},{Longitude}";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(Object other) 
            => other is GeoCoordinate coordinate && Equals(coordinate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(GeoCoordinate other) 
            => Latitude == other.Latitude && Longitude == other.Longitude;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() 
            => Latitude.GetHashCode() ^ Longitude.GetHashCode();
    }
}