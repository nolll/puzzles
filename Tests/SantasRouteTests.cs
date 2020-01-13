using System.Collections.Generic;
using System.Linq;
using Core.Tools;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    public class SantasRouteTests
    {
        [Test]
        public void CalculateShortestRoute()
        {
            const string input = @"
London to Dublin = 464
London to Belfast = 518
Dublin to Belfast = 141";

            var calculator = new RouteCalculator(input);

            Assert.That(calculator.ShortestDistance, Is.EqualTo(605));
        }
    }

    public class RouteCalculator
    {
        private readonly IDictionary<string, int> _distanceDictionary;
        
        public int ShortestDistance { get; }

        public RouteCalculator(string input)
        {
            var distances = GetDistances(input);
            _distanceDictionary = GetDistanceDictionary(distances);
            var locations = GetLocations(distances);
            var routes = GetRoutes(locations);
            ShortestDistance = FindShortestDistance(routes);
        }

        private int FindShortestDistance(IList<IEnumerable<string>> routes)
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

        private int CalculateRouteLength(IList<string> route)
        {
            var length = 0;
            for (var i = 0; i < route.Count - 1; i++)
            {
                var from = route[0];
                var to = route[1];
                var key = GetKey(from, to);
                var distance = _distanceDictionary[key];
                length += distance;
            }

            return length;
        }

        private IList<IEnumerable<string>> GetRoutes(IList<string> locations)
        {
            return new PermutationGenerator().GetPermutations(locations).ToList();
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
            return PuzzleInputReader.Read(input).Select(CreateDistance).ToList();
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

    public class Distance
    {
        public string From { get; }
        public string To { get; }
        public int Dist { get; }

        public Distance(string from, string to, int dist)
        {
            From = @from;
            To = to;
            Dist = dist;
        }
    }
}