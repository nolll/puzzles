using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Experimental Emergency Teleportation")]
public class Aoc201823 : AocPuzzle
{
    private readonly Point3d _origo = new(0, 0, 0);
    
    [Puzzle("1f18b10dba77e2b98fd66c448d160fe8")]
    public int Part1(string input) => GetBotsInRangeOfStrongestBot(input).Count();

    [Puzzle("63c2a383a835ff3ea383e54f860c8516")]
    public int Part2(string input) => FindManhattanDistanceToBestCoords(input);

    private IEnumerable<Nanobot> GetBotsInRangeOfStrongestBot(string input)
    {
        var bots = ParseBots(input);
        var strongestBot = FindStrongestBot(bots);
        return bots.Where(strongestBot.IsInRange);
    }

    private int FindManhattanDistanceToBestCoords(string input)
    {
        var bots = ParseBots(input);
        var maxRadius = bots.Max(o => o.SignalRadius);
        var padding = maxRadius;

        var xMin = bots.Min(o => o.Coords.X) - padding;
        var xMax = bots.Max(o => o.Coords.X) + padding;
        var yMin = bots.Min(o => o.Coords.Y) - padding;
        var yMax = bots.Max(o => o.Coords.Y) + padding;
        var zMin = bots.Min(o => o.Coords.Z) - padding;
        var zMax = bots.Max(o => o.Coords.Z) + padding;

        var rootBox = new SpaceBox(new Point3d(xMin, yMin, zMin), new Point3d(xMax, yMax, zMax));
        var bestBox = FindBestCoords(bots, rootBox);
        var bestCoords = FindBestCoordsInBestBox(bots, bestBox);

        return bestCoords.Min(o => o.ManhattanDistanceTo(_origo));
    }

    private static IList<Point3d> FindBestCoordsInBestBox(IList<Nanobot> bots, SpaceBox? box)
    {
        if (box is null)
            return new List<Point3d>();

        var mostBots = 0;
        var bestCoords = new List<Point3d>();

        for (var x = box.Min.X; x <= box.Max.X; x++)
        {
            for (var y = box.Min.Y; y <= box.Max.Y; y++)
            {
                for (var z = box.Min.Z; z <= box.Max.Z; z++)
                {
                    var botCount = bots.Count(o => o.IsInRange(x, y, z));
                    if (botCount > mostBots)
                    {
                        mostBots = botCount;
                        bestCoords = [new(x, y, z)];
                    }
                    else if (botCount == mostBots)
                    {
                        bestCoords.Add(new(x, y, z));
                    }
                }
            }
        }

        return bestCoords;
    }

    private class PriorityQueue
    {
        private readonly Dictionary<int, IList<PriorityQueueItem>> _dict = new();
        public int Length { get; private set; }

        public void Enqueue(PriorityQueueItem item)
        {
            if (_dict.TryGetValue(item.BotsInRange, out var list))
                list.Add(item);
            else
                _dict.Add(item.BotsInRange, new List<PriorityQueueItem> { item });
            Length++;
        }

        public PriorityQueueItem Dequeue()
        {
            var maxBots = _dict.Keys.Max();
            var list = _dict[maxBots];
            var item = list.OrderByDescending(o => o.BoxSize).ThenBy(o => o.DistanceFromOrigo).First();
            list.Remove(item);
            if (!list.Any())
                _dict.Remove(maxBots);
            Length--;
            return item;
        }
    }

    private record PriorityQueueItem(SpaceBox Box, int BotsInRange, int DistanceFromOrigo) : IEquatable<PriorityQueueItem>
    {
        public long BoxSize { get; } = Box.Size;
    }

    private SpaceBox? FindBestCoords(IList<Nanobot> bots, SpaceBox rootBox)
    {
        var queue = new PriorityQueue();
        queue.Enqueue(new PriorityQueueItem(rootBox, CountBotsInRange(bots, rootBox), ManhattanDistanceTo(_origo, rootBox)));
        while (queue.Length > 0)
        {
            var current = queue.Dequeue();
            if (current.BoxSize == 1)
                return current.Box;

            var subBoxes = DivideBox(current.Box).ToList();
            foreach (var subBox in subBoxes)
            {
                queue.Enqueue(new PriorityQueueItem(subBox, CountBotsInRange(bots, subBox), ManhattanDistanceTo(_origo, subBox)));
            }
        }

        return null;
    }

    private int CountBotsInRange(IList<Nanobot> bots, SpaceBox spaceBox) => bots.Count(o => IsInRange(o, spaceBox));

    private static int ManhattanDistanceTo(Point3d point, SpaceBox box) =>
        point.ManhattanDistanceTo(GetClosestPoint(point, box));

    private bool IsInRange(Nanobot bot, SpaceBox box) => ManhattanDistanceTo(bot.Coords, box) <= bot.SignalRadius;

    private static Point3d GetClosestPoint(Point3d point, SpaceBox box)
    {
        var x = point.X;
        if (x < box.Min.X)
            x = box.Min.X;
        else if (x > box.Max.X)
            x = box.Max.X;

        var y = point.Y;
        if (y < box.Min.Y)
            y = box.Min.Y;
        else if (y > box.Max.Y)
            y = box.Max.Y;

        var z = point.Z;
        if (z < box.Min.Z)
            z = box.Min.Z;
        else if (z > box.Max.Z)
            z = box.Max.Z;
        
        return new Point3d(x, y, z);
    }

    private static IEnumerable<SpaceBox> DivideBox(SpaceBox box) => box.Divide();
    private static Nanobot FindStrongestBot(IList<Nanobot> bots) => bots.OrderByDescending(o => o.SignalRadius).First();
    public static IList<Nanobot> ParseBots(string input) => [.. input.Split(LineBreaks.Single).Select(ParseBot)];

    private static Nanobot ParseBot(string s)
    {
        var (x, y, z, radius) = Numbers.IntsFromString(s);
        return new Nanobot(new Point3d(x, y, z), radius);
    }
    
    public record Nanobot(Point3d Coords, int SignalRadius)
    {
        public bool IsInRange(Nanobot otherBot) => ManhattanDistanceTo(otherBot) <= SignalRadius;
        public bool IsInRange(int x, int y, int z) => ManhattanDistanceTo(x, y, z) <= SignalRadius;
        private int ManhattanDistanceTo(Nanobot other) => Coords.ManhattanDistanceTo(other.Coords);
        private int ManhattanDistanceTo(int x, int y, int z) => Coords.ManhattanDistanceTo(x, y, z);
    }

    public record Point3d(int X, int Y, int Z)
    {
        public int ManhattanDistanceTo(Point3d other) => ManhattanDistanceTo(other.X, other.Y, other.Z);

        public int ManhattanDistanceTo(int x, int y, int z) => 
            Math.Max(X, x) - Math.Min(X, x) + (Math.Max(Y, y) - Math.Min(Y, y)) + (Math.Max(Z, z) - Math.Min(Z, z));
    }

    public record SpaceBox(Point3d Min, Point3d Max)
    {
        private int SizeX => Max.X - Min.X + 1;
        private int SizeY => Max.Y - Min.Y + 1;
        private int SizeZ => Max.Z - Min.Z + 1;
        public long Size => (long)SizeX * SizeY * SizeZ;

        public IEnumerable<SpaceBox> Divide()
        {
            var xMid = Min.X + SizeX / 2;
            var yMid = Min.Y + SizeY / 2;
            var zMid = Min.Z + SizeZ / 2;

            var splitX = SizeX > 1;
            var splitY = SizeY > 1;
            var splitZ = SizeZ > 1;

            var x1Min = Min.X;
            var x1Max = splitX ? xMid - 1 : xMid;
            var x2Min = xMid;
            var x2Max = Max.X;

            var y1Min = Min.Y;
            var y1Max = splitY ? yMid - 1 : yMid;
            var y2Min = yMid;
            var y2Max = Max.Y;

            var z1Min = Min.Z;
            var z1Max = splitZ ? zMid - 1 : zMid;
            var z2Min = zMid;
            var z2Max = Max.Z;

            yield return new SpaceBox(new Point3d(x1Min, y1Min, z1Min), new Point3d(x1Max, y1Max, z1Max));

            if (splitX)
                yield return new SpaceBox(new Point3d(x2Min, y1Min, z1Min), new Point3d(x2Max, y1Max, z1Max));

            if (splitY)
                yield return new SpaceBox(new Point3d(x1Min, y2Min, z1Min), new Point3d(x1Max, y2Max, z1Max));

            if (splitZ)
                yield return new SpaceBox(new Point3d(x1Min, y1Min, z2Min), new Point3d(x1Max, y1Max, z2Max));

            if (splitX && splitY)
                yield return new SpaceBox(new Point3d(x2Min, y2Min, z1Min), new Point3d(x2Max, y2Max, z1Max));

            if (splitX && splitZ)
                yield return new SpaceBox(new Point3d(x2Min, y1Min, z2Min), new Point3d(x2Max, y1Max, z2Max));

            if (splitY && splitZ)
                yield return new SpaceBox(new Point3d(x1Min, y2Min, z2Min), new Point3d(x1Max, y2Max, z2Max));

            if (splitX && splitY && splitZ)
                yield return new SpaceBox(new Point3d(x2Min, y2Min, z2Min), new Point3d(x2Max, y2Max, z2Max));
        }
    }
}