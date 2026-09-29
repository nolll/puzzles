using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("All in a Single Night")]
public class Aoc201509 : AocPuzzle
{
    [Puzzle("4cc29488fe313222695140cafd29224d")]
    public int Part1(string input)
    {
        var (routes, distances) = GetRoutesAndDistances(input);
        return FindShortestDistance(distances, routes);
    }

    [Puzzle("6d5195b794f070d181a56006b064ff95")]
    public int Part2(string input)
    {
        var (routes, distances) = GetRoutesAndDistances(input);
        return FindLongestDistance(distances, routes);
    }

    private (List<List<string>> routes, IDictionary<string, int> distances) GetRoutesAndDistances(string input)
    {
        var distances = GetDistances(input);
        var distanceDictionary = GetDistanceDictionary(distances);
        var locations = GetLocations(distances);
        var routes = GetRoutes(locations);
        return (routes, distanceDictionary);
    }

    private int FindShortestDistance(IDictionary<string, int> distances, List<List<string>> routes)
    {
        int? shortestRoute = null;
        foreach (var route in routes)
        {
            var routeLength = CalculateRouteLength(distances, route.ToList());
            if (shortestRoute == null || routeLength < shortestRoute.Value)
                shortestRoute = routeLength;
        }

        return shortestRoute ?? 0;
    }

    private int FindLongestDistance(IDictionary<string, int> distances, List<List<string>> routes)
    {
        int? longestRoute = null;
        foreach (var route in routes)
        {
            var routeLength = CalculateRouteLength(distances, route.ToList());
            if (longestRoute == null || routeLength > longestRoute.Value)
                longestRoute = routeLength;
        }

        return longestRoute ?? 0;
    }

    private int CalculateRouteLength(IDictionary<string, int> distances, IList<string> route)
    {
        var totalDistance = 0;
        for (var i = 0; i < route.Count - 1; i++)
        {
            var from = route[i];
            var to = route[i + 1];
            var key = GetKey(from, to);
            var distance = distances[key];
            totalDistance += distance;
        }

        return totalDistance;
    }

    private static List<List<string>> GetRoutes(IList<string> locations) =>
        PermutationGenerator.GetPermutations(locations).Select(o => o.ToList()).ToList();

    private static IList<string> GetLocations(IList<Distance> distances)
    {
        var locations = new List<string>();
        foreach (var distance in distances)
        {
            if (!locations.Contains(distance.From))
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

    private static string GetKey(string from, string to) => $"{from}->{to}";

    private static IList<Distance> GetDistances(string input) =>
        input.Split(LineBreaks.Single).Select(CreateDistance).ToList();

    private static Distance CreateDistance(string s)
    {
        var (from, _, to, _, dist) = s.Split(' ');
        return new Distance(from, to, int.Parse(dist));
    }

    private class Distance(string from, string to, int dist)
    {
        public string From { get; } = from;
        public string To { get; } = to;
        public int Dist { get; } = dist;
    }
}