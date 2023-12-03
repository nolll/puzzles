using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2018.Aoc201823;

public class NanobotFormation
{
    private readonly Point3d _origo = new(0, 0, 0);
    private readonly IList<Nanobot> _bots;

    public NanobotFormation(string input)
    {
        _bots = ParseBots(input);
    }

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

    public class PriorityQueue
    {
        private readonly Dictionary<int, IList<PriorityQueueItem>> _dict;
        public int Length { get; private set; }

        public PriorityQueue()
        {
            _dict = new Dictionary<int, IList<PriorityQueueItem>>();
            Length = 0;
        }

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

    public class PriorityQueueItem : IEquatable<PriorityQueueItem>
    {
        public string Id { get; }
        public SpaceBox Box { get; }
        public long BoxSize { get; }
        public int BotsInRange { get; }
        public int DistanceFromOrigo { get; }

        public PriorityQueueItem(SpaceBox box, int botsInRange, int distanceFromOrigo)
        {
            Id = $"{box.Min.X},{box.Min.Y},{box.Min.Z}-{box.Max.X},{box.Max.Y},{box.Max.Z}:{box.Size}";
            Box = box;
            BoxSize = box.Size;
            BotsInRange = botsInRange;
            DistanceFromOrigo = distanceFromOrigo;
        }

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
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PriorityQueueItem) obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }
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

    private int CountBotsInRange(SpaceBox spaceBox)
    {
        return _bots.Count(o => IsInRange(o, spaceBox));
    }

    private int ManhattanDistanceTo(Point3d point, SpaceBox box)
    {
        var closestPoint = GetClosestPoint(point, box);
        return point.ManhattanDistanceTo(closestPoint);
    }

    private bool IsInRange(Nanobot bot, SpaceBox box)
    {
        var distance = ManhattanDistanceTo(bot.Coords, box);
        return distance <= bot.SignalRadius;
    }

    private bool IsInRange2(Nanobot bot, SpaceBox box)
    {
        var dist1 = bot.Coords.ManhattanDistanceTo(box.Max.X, box.Max.Y, box.Max.Z);
        var dist2 = bot.Coords.ManhattanDistanceTo(box.Max.X, box.Max.Y, box.Min.Z);
        var dist3 = bot.Coords.ManhattanDistanceTo(box.Max.X, box.Min.Y, box.Max.Z);
        var dist4 = bot.Coords.ManhattanDistanceTo(box.Max.X, box.Min.Y, box.Min.Z);

        var dist5 = bot.Coords.ManhattanDistanceTo(box.Min.X, box.Max.Y, box.Max.Z);
        var dist6 = bot.Coords.ManhattanDistanceTo(box.Min.X, box.Max.Y, box.Min.Z);
            
        var dist7 = bot.Coords.ManhattanDistanceTo(box.Min.X, box.Min.Y, box.Max.Z);
            
        var dist8 = bot.Coords.ManhattanDistanceTo(box.Min.X, box.Min.Y, box.Min.Z);

        return dist1 <= bot.SignalRadius &&
               dist2 <= bot.SignalRadius &&
               dist3 <= bot.SignalRadius &&
               dist4 <= bot.SignalRadius &&
               dist5 <= bot.SignalRadius &&
               dist6 <= bot.SignalRadius &&
               dist7 <= bot.SignalRadius &&
               dist8 <= bot.SignalRadius;
    }

    private Point3d GetClosestPoint(Point3d point, SpaceBox box)
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

    private IEnumerable<SpaceBox> DivideBox(SpaceBox box)
    {
        return box.Divide();
    }

    private Nanobot FindStrongestBot()
    {
        return _bots.OrderByDescending(o => o.SignalRadius).First();
    }

    public IList<Nanobot> GetBotsInRangeOfStrongestBot()
    {
        var strongestBot = FindStrongestBot();
        return _bots.Where(o => strongestBot.IsInRange(o)).ToList();
    }

    private IList<Nanobot> ParseBots(string input)
    {
        return StringReader.ReadLines(input).Select(ParseBot).ToList();
    }

    private Nanobot ParseBot(string s)
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