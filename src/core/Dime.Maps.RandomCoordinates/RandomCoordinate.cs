using System;
using System.Collections.Generic;

namespace Dime.Maps.RandomCoordinates
{
    /// <summary>
    /// .NET port of answer recommended by https://stackoverflow.com/a/31280435/1842261
    /// </summary>
    public class RandomCoordinate
    {
        public static IEnumerable<Coordinate> Next(Coordinate center, int radius, int amount)
        {
            for (int i = 0; i < amount; i++)
                yield return Next(center, radius);
        }

        public static Coordinate Next(Coordinate center, int radius)
        {
            double y0 = center.Latitude;
            double x0 = center.Longitude;
            float rd = (float)radius / (float)111300; // About 111300 meters in one degree

            Random rnd = new();

            double u = rnd.NextDouble();
            double v = rnd.NextDouble();

            double w = rd * Math.Sqrt(u);
            double t = 2 * Math.PI * v;
            double x = w * Math.Cos(t);
            double y = w * Math.Sin(t);

            double newLat = y + y0;
            double newLong = x + x0;

            return new Coordinate(newLat, newLong);
        }
    }
}