using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201823;

public class NanobotFormation(string input)
{
    private readonly Point3d _origo = new(0, 0, 0);
    private readonly IList<Nanobot> _bots = ParseBots(input);

    public int FindManhattanDistanceToBestCoords()
    {
        var maxRadius = _bots.Max(o => o.SignalRadius);
        var padding = maxRadius;

        var xMin = _bots.Min(o => o.Coords.X) - padding;
        var xMax = _bots.Max(o => o.Coords.X) + padding;
        var yMin = _bots.Min(o => o.Coords.Y) - padding;
        var yMax = _bots.Max(o => o.Coords.Y) + padding;
        var zMin = _bots.Min(o => o.Coords.Z) - padding;
        var zMax = _bots.Max(o => o.Coords.Z) + padding;
            
        var rootBox = new SpaceBox(new Point3d(xMin, yMin, zMin), new Point3d(xMax, yMax, zMax));
        var bestBox = FindBestCoords(rootBox);

        var bestCoords = FindBestCoordsInBestBox(bestBox);

        return bestCoords.Min(o => o.ManhattanDistanceTo(_origo));
    }

    private IList<Point3d> FindBestCoordsInBestBox(SpaceBox? box)
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
                    var botCount = _bots.Count(o => o.IsInRange(x, y, z));
                    if (botCount > mostBots)
                    {
                        mostBots = botCount;
                        bestCoords = new List<Point3d> { new(x, y, z) };
                    }
                    else if (botCount == mostBots)
                    {
                        bestCoords.Add(new Point3d(x, y, z));
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
            if(_dict.TryGetValue(item.BotsInRange, out var list))
                list.Add(item);
            else
                _dict.Add(item.BotsInRange, new List<PriorityQueueItem>{item});
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

    public class PriorityQueueItem(SpaceBox box, int botsInRange, int distanceFromOrigo) : IEquatable<PriorityQueueItem>
    {
        private string Id { get; } = $"{box.Min.X},{box.Min.Y},{box.Min.Z}-{box.Max.X},{box.Max.Y},{box.Max.Z}:{box.Size}";
        public SpaceBox Box { get; } = box;
        public long BoxSize { get; } = box.Size;
        public int BotsInRange { get; } = botsInRange;
        public int DistanceFromOrigo { get; } = distanceFromOrigo;

        public bool Equals(PriorityQueueItem? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((PriorityQueueItem) obj);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }

    private SpaceBox? FindBestCoords(SpaceBox rootBox)
    {
        var queue = new PriorityQueue();
        queue.Enqueue(new PriorityQueueItem(rootBox, CountBotsInRange(rootBox), ManhattanDistanceTo(_origo, rootBox)));
        while (queue.Length > 0)
        {
            var current = queue.Dequeue();
            if (current.BoxSize == 1)
                return current.Box;

            var subBoxes = DivideBox(current.Box).ToList();
            foreach (var subBox in subBoxes)
            {
                queue.Enqueue(new PriorityQueueItem(subBox, CountBotsInRange(subBox), ManhattanDistanceTo(_origo, subBox)));
            }
        }

        return null;
    }

    private int CountBotsInRange(SpaceBox spaceBox) => _bots.Count(o => IsInRange(o, spaceBox));

    private static int ManhattanDistanceTo(Point3d point, SpaceBox box) => 
        point.ManhattanDistanceTo(GetClosestPoint(point, box));

    private bool IsInRange(Nanobot bot, SpaceBox box) => ManhattanDistanceTo(bot.Coords, box) <= bot.SignalRadius;

    private static Point3d GetClosestPoint(Point3d point, SpaceBox box)
    {
        var x = point.X;
        var y = point.Y;
        var z = point.Z;

        if (x < box.Min.X)
            x = box.Min.X;
        else if (x > box.Max.X)
            x = box.Max.X;

        if (y < box.Min.Y)
            y = box.Min.Y;
        else if (y > box.Max.Y)
            y = box.Max.Y;

        if (z < box.Min.Z)
            z = box.Min.Z;
        else if (z > box.Max.Z)
            z = box.Max.Z;
        return new Point3d(x, y, z);
    }

    private static IEnumerable<SpaceBox> DivideBox(SpaceBox box) => box.Divide();

    private Nanobot FindStrongestBot() => _bots.OrderByDescending(o => o.SignalRadius).First();

    public IList<Nanobot> GetBotsInRangeOfStrongestBot()
    {
        var strongestBot = FindStrongestBot();
        return _bots.Where(o => strongestBot.IsInRange(o)).ToList();
    }

    private static IList<Nanobot> ParseBots(string input) => 
        input.Split(LineBreaks.Single).Select(ParseBot).ToList();

    private static Nanobot ParseBot(string s)
    {
        var parts = s.Split(' ');
        var coordParts = parts[0].Replace("pos=<", "").Replace(">", "").Split(',');
        var x = int.Parse(coordParts[0]);
        var y = int.Parse(coordParts[1]);
        var z = int.Parse(coordParts[2]);
        var radius = int.Parse(parts[1].Replace("r=", ""));
        return new Nanobot(new Point3d(x, y, z), radius);
    }
}