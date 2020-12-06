using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.SantasRoute
{
    public class RouteCalculator
    {
        private readonly IDictionary<string, int> _distanceDictionary;

        public int ShortestDistance { get; }
        public int LongestDistance { get; }

        public RouteCalculator(string input)
        {
            var distances = GetDistances(input);
            _distanceDictionary = GetDistanceDictionary(distances);
            var locations = GetLocations(distances);
            var routes = GetRoutes(locations);
            ShortestDistance = FindShortestDistance(routes);
            LongestDistance = FindLongestDistance(routes);
        }

        private int FindShortestDistance(List<List<string>> routes)
        {
            int? shortestRoute = null;
            foreach (var route in routes)
            {
                var routeLength = CalculateRouteLength(route.ToList());
                if (shortestRoute == null || routeLength < shortestRoute.Value)
                    shortestRoute = routeLength;
            }
            return shortestRoute ?? 0;
        }

        private int FindLongestDistance(List<List<string>> routes)
        {
            int? longestRoute = null;
            foreach (var route in routes)
            {
                var routeLength = CalculateRouteLength(route.ToList());
                if (longestRoute == null || routeLength > longestRoute.Value)
                    longestRoute = routeLength;
            }
            return longestRoute ?? 0;
        }

        private int CalculateRouteLength(IList<string> route)
        {
            var totalDistance = 0;
            for (var i = 0; i < route.Count - 1; i++)
            {
                var from = route[i];
                var to = route[i + 1];
                var key = GetKey(from, to);
                var distance = _distanceDictionary[key];
                totalDistance += distance;
            }

            return totalDistance;
        }

        private List<List<string>> GetRoutes(IList<string> locations)
        {
            return PermutationGenerator.GetPermutations(locations).Select(o => o.ToList()).ToList();
        }

        private IList<string> GetLocations(IList<Distance> distances)
        {
            var locations = new List<string>();
            foreach (var distance in distances)
            {
                if(!locations.Contains(distance.From))
                    locations.Add(distance.From);
                if (!locations.Contains(distance.To))
                    locations.Add(distance.To);
            }

            return locations;
        }

        private IDictionary<string, int> GetDistanceDictionary(IList<Distance> distances)
        {
            var dictionary = new Dictionary<string, int>();
            foreach (var distance in distances)
            {
                dictionary.Add(GetKey(distance.From, distance.To), distance.Dist);
                dictionary.Add(GetKey(distance.To, distance.From), distance.Dist);
            }

            return dictionary;
        }

        private string GetKey(string from, string to)
        {
            return $"{from}->{to}";
        }

        private IList<Distance> GetDistances(string input)
        {
            return PuzzleInputReader.ReadLines(input).Select(CreateDistance).ToList();
        }

        private Distance CreateDistance(string s)
        {
            var parts = s.Split(' ');
            var from = parts[0];
            var to = parts[2];
            var dist = int.Parse(parts[4]);
            return new Distance(from, to, dist);
        }
    }
}