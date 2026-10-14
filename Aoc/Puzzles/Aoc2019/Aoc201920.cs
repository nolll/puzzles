using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Donut Maze")]
public class Aoc201920 : AocPuzzle
{
    [Puzzle("58adb5666e2e47bbe945955687e3e3c6")]
    public int Part1(string input)
    {
        var map = BuildMap(input);
        var portals = FindPortals(map);
        var portalConnections = FindPortalConnections(map, portals);
        var stepCounts = StepCountsTo(portalConnections, "AA", "ZZ").OrderBy(o => o.Distance).ToList();
        return stepCounts.First().Distance;
    }

    [Puzzle("01cf53a29e92f3092e973f5c97ac5595")]
    public int Part2(string input)
    {
        var (startAddress, endAddress, portals, cache) = Init(input);
        return StepCountTo(startAddress, endAddress, portals, cache);
    }

    private static IEnumerable<PortalPath> StepCountsTo(IDictionary<string, int> portalConnections, string startPortal, string targetPortal)
    {
        var completePaths = new List<PortalPath>();
        var queue = new Queue<PortalPath>([new(0, startPortal, new List<string> { "AA" })]);
        while (queue.Count != 0)
        {
            var path = queue.Dequeue();

            var possibleConnections = portalConnections.Keys.Where(o => o.Contains(path.FromPortal));
            foreach (var connection in possibleConnections)
            {
                var otherId = connection.Replace(path.FromPortal, "").Replace("-", "");
                if (!path.PassedPortals.Contains(otherId))
                {
                    if (otherId == targetPortal)
                    {
                        var distance = path.Distance + portalConnections[connection];
                        var newPath = new PortalPath(distance, otherId, path.PassedPortals.Concat(new List<string> { otherId }).ToList());
                        completePaths.Add(newPath);
                    }
                    else
                    {
                        var distance = path.Distance + portalConnections[connection] + 1;
                        var newPath = new PortalPath(distance, otherId, path.PassedPortals.Concat(new List<string> { otherId }).ToList());
                        queue.Enqueue(newPath);
                    }
                }
            }
        }

        return completePaths;
    }

    private record PortalPath
    {
        public int Distance { get; }
        public string FromPortal { get; }
        public IList<string> PassedPortals { get; }

        public PortalPath(int distance, string fromPortal, IList<string>? passedPortals = null)
        {
            Distance = distance;
            FromPortal = fromPortal;
            PassedPortals = passedPortals ?? new List<string>();
        }
    }

    private static IDictionary<string, int> FindPortalConnections(Grid<char> map, IList<DonutPortalAddress> portals)
    {
        var connections = new Dictionary<string, int>();

        foreach (var a in portals)
        {
            foreach (var b in portals)
            {
                if (a.Name == b.Name)
                    continue;

                var id = GetPortalDistanceId(a, b);
                if (connections.ContainsKey(id))
                    continue;

                var distance = PathFinder.ShortestPathTo(map, a.Address, b.Address).Count();
                if (distance > 0)
                    connections[id] = distance - 2;
            }
        }

        return connections;
    }

    private static string GetPortalDistanceId(DonutPortalAddress a, DonutPortalAddress b)
        => GetPortalDistanceId(a.Name, b.Name);

    private static string GetPortalDistanceId(string a, string b)
        => string.Join('-', new[] { a, b }.OrderBy(o => o));

    private static IList<DonutPortalAddress> FindPortals(Grid<char> map)
    {
        var portals = new List<DonutPortalAddress>();
        var letterCoords = FindLetterCoords(map).ToList();
        while (letterCoords.Count > 0)
        {
            var currentCoords = letterCoords.First();
            letterCoords.RemoveAt(0);
            var secondsLetterCoords = map.OrthogonalAdjacentCoordsTo(currentCoords).First(o => IsLetter(map.ReadValueAt(o)));
            var firstLetter = map.ReadValueAt(currentCoords);
            var secondLetter = map.ReadValueAt(secondsLetterCoords);
            letterCoords.Remove(secondsLetterCoords);
            map.WriteValueAt(currentCoords, Chars.Wall);
            map.WriteValueAt(secondsLetterCoords, Chars.Wall);
            var secondLetterHasAdjacentCorridor = map.OrthogonalAdjacentValuesTo(secondsLetterCoords).Any(o => o == Chars.Path);
            var name = string.Concat(firstLetter, secondLetter);
            var portalAddress = secondLetterHasAdjacentCorridor ? secondsLetterCoords : currentCoords;
            map.WriteValueAt(portalAddress, Chars.Path);
            var portal = new DonutPortalAddress(name, portalAddress);
            portals.Add(portal);
        }

        return portals;
    }
    
    private static Grid<char> BuildMap(string input) => GridBuilder.BuildCharGrid(input.Replace(Chars.Space, Chars.Wall));

    private abstract record DonutPortal(Coord Target, int DepthChange);
    private record DonutPortalAddress(string Name, Coord Address);
    private record InnerDonutPortal(Coord Target) : DonutPortal(Target, 1);
    private record OuterDonutPortal(Coord Target) : DonutPortal(Target, -1);
    
    private static class Chars
    {
        public const char Path = '.';
        public const char Wall = '#';
        public const char Space = ' ';
    }

    private (Coord, Coord, Dictionary<Coord, DonutPortal>, Cache) Init(string input)
    {
        Coord startAddress = new(0, 0);
        Coord endAddress = new(0, 0);

        var grid = GridBuilder.BuildCharGrid(input.Replace(Chars.Space, Chars.Wall));
        var portalAddresses = new List<DonutPortalAddress>();
        var letterCoords = FindLetterCoords(grid).ToList();
        while (letterCoords.Count > 0)
        {
            var currentCoords = letterCoords.First();
            letterCoords.RemoveAt(0);
            grid.MoveTo(currentCoords);
            var secondLetterCoords = grid.OrthogonalAdjacentCoords.First(o => IsLetter(grid.ReadValueAt(o)));
            var firstLetter = grid.ReadValueAt(currentCoords);
            var secondLetter = grid.ReadValueAt(secondLetterCoords);
            letterCoords.Remove(secondLetterCoords);
            grid.MoveTo(currentCoords);
            grid.WriteValue(Chars.Wall);
            grid.MoveTo(secondLetterCoords);
            grid.WriteValue(Chars.Wall);
            var secondLetterHasAdjacentCorridor = grid.OrthogonalAdjacentValues.Any(o => o == Chars.Path);
            grid.MoveTo(currentCoords);
            var name = string.Concat(firstLetter, secondLetter);
            var letterAddress = secondLetterHasAdjacentCorridor ? secondLetterCoords : currentCoords;
            grid.MoveTo(letterAddress);
            var portalAddress = grid.OrthogonalAdjacentCoords.First(o => grid.ReadValueAt(o) == Chars.Path);
            if (name == "AA")
            {
                startAddress = portalAddress;
                continue;
            }

            if (name == "ZZ")
            {
                endAddress = portalAddress;
                continue;
            }

            grid.MoveTo(portalAddress);
            grid.WriteValue(Chars.Path);
            var portal = new DonutPortalAddress(name, portalAddress);
            portalAddresses.Add(portal);
        }

        var portals = new Dictionary<Coord, DonutPortal>();
        var orderedPortalAddresses = portalAddresses.OrderBy(o => o.Name).ToList();
        var topGrid = grid.Clone();

        while (orderedPortalAddresses.Count != 0)
        {
            var a = orderedPortalAddresses.First();
            orderedPortalAddresses.RemoveAt(0);
            var b = orderedPortalAddresses.First();
            orderedPortalAddresses.RemoveAt(0);

            var aIsOuter = IsOuterPortal(grid, a.Address);
            var outer = aIsOuter ? a : b;
            var inner = aIsOuter ? b : a;

            var innerPortal = new InnerDonutPortal(outer.Address);
            portals.Add(inner.Address, innerPortal);
            var outerPortal = new OuterDonutPortal(inner.Address);
            portals.Add(outer.Address, outerPortal);
            topGrid.MoveTo(outer.Address);
            topGrid.WriteValue(Chars.Wall);
        }

        var cache = new Cache(BuildAdjacentCache(topGrid), BuildAdjacentCache(grid));
        return (startAddress, endAddress, portals, cache);
    }

    private static IDictionary<Coord, IList<Coord>> BuildAdjacentCache(Grid<char> grid)
    {
        var dictionary = new Dictionary<Coord, IList<Coord>>();
        foreach (var coord in grid.Coords)
        {
            var coords = grid
                .OrthogonalAdjacentCoordsTo(coord)
                .Where(o => grid.ReadValueAt(o) == Chars.Path)
                .ToList();
            dictionary.Add(coord, coords);
        }

        return dictionary;
    }

    private static bool IsOuterPortal(Grid<char> grid, Coord address)
    {
        const int distance = 2;
        var xIsOnEdge = grid.XMin + distance == address.X || grid.XMax - distance == address.X;
        var yIsOnEdge = grid.YMin + distance == address.Y || grid.YMax - distance == address.Y;
        return xIsOnEdge || yIsOnEdge;
    }

    private static IEnumerable<Coord> FindLetterCoords(Grid<char> grid) =>
        grid.Coords.Where(o => IsLetter(grid.ReadValueAt(o)));

    private static bool IsLetter(char c) => c != Chars.Wall && c != Chars.Path;

    private int StepCountTo(Coord from,
        Coord to,
        Dictionary<Coord, DonutPortal> portals,
        Cache cache)
    {
        var coordCounts = GetCoordCounts(from, to, portals, cache);
        var goal = coordCounts.FirstOrDefault(o => o.Depth == 0 && o.Coord.X == from.X && o.Coord.Y == from.Y);
        return goal?.Count ?? 0;
    }

    private IList<Coord> GetAdjacentCoords(
        Coord coord,
        int depth,
        Cache cache) => cache.Get(coord, depth);

    private IList<CoordCount> GetCoordCounts(Coord from,
        Coord to,
        Dictionary<Coord, DonutPortal> portals,
        Cache cache)
    {
        var queue = new List<CoordCount> { new(0, to, 0) };
        var seen = new HashSet<(int, int, int)>();
        var index = 0;
        while (index < queue.Count && !seen.Contains((0, from.X, from.Y)))
        {
            var next = queue[index];
            var adjacentCoords = GetAdjacentCoords(next.Coord, next.Depth, cache)
                .Where(o => !seen.Contains((next.Depth, o.X, o.Y)))
                .ToList();

            foreach (var adjacentCoord in adjacentCoords)
            {
                var newCoordCount = new CoordCount(next.Depth, adjacentCoord, next.Count + 1);
                queue.Add(newCoordCount);
                seen.Add((newCoordCount.Depth, newCoordCount.Coord.X, newCoordCount.Coord.Y));
            }

            if (portals.TryGetValue(next.Coord, out var portal))
            {
                var portalCoordCount = new CoordCount(next.Depth + portal.DepthChange, portal.Target, next.Count + 1);
                queue.Add(portalCoordCount);
                seen.Add((portalCoordCount.Depth, portalCoordCount.Coord.X, portalCoordCount.Coord.Y));
            }

            index++;
        }

        return queue;
    }

    private class Cache(IDictionary<Coord, IList<Coord>> outerCache, IDictionary<Coord, IList<Coord>> innerCache)
    {
        public IList<Coord> Get(Coord coord, int depth) => SelectCache(depth)[coord];
        private IDictionary<Coord, IList<Coord>> SelectCache(int depth) => depth == 0 ? outerCache : innerCache;
    }

    private record CoordCount(int Depth, Coord Coord, int Count);
}