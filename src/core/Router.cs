﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core.GeoJson;
using Azure.Maps.Routing;
using Azure.Maps.Routing.Models;

namespace TurtleRoute
{
    public class Router
    {
        public Router(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException(nameof(token));

            Token = token;
        }

        private string Token { get; }

        public async Task<IEnumerable<GeoCoordinate>> GetDirectionsAsync(params GeoCoordinate[] coordinates)
        {
            AzureKeyCredential credential = new(Token);
            MapsRoutingClient client = new(credential);

            IEnumerable<GeoPosition> waypoints = coordinates.ToList().Select(x => new GeoPosition(x.Longitude, x.Latitude));
            RouteDirectionQuery query = new(waypoints.ToList());
            Response<RouteDirections> result = await client.GetDirectionsAsync(query);

            return result.Value.Routes[0].Legs.SelectMany(x => x.Points).Select(x => new GeoCoordinate(x.Latitude, x.Longitude));
        }
    }
}