using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Crossed Wires")]
public class Aoc201903 : AocPuzzle
{
    [Puzzle("3dbd15d37a682cfa1ca55525a248c184")]
    public int Part1(string input)
    {
        var (a, b) = input.Split(LineBreaks.Single);
        return new IntersectionFinder(a, b).ClosestIntersection.Distance;
    }

    [Puzzle("51670676a41763c6093416dd009a8ba6")]
    public int Part2(string input)
    {
        var (a, b) = input.Split(LineBreaks.Single);
        return new IntersectionFinder(a, b).FewestSteps.Steps;
    }
    
    public class IntersectionFinder
    {
        public Point ClosestIntersection { get; }
        public Point FewestSteps { get; }

        public IntersectionFinder(string pathA, string pathB)
        {
            var commandSequenceA = GetCommands(pathA);
            var commandSequenceB = GetCommands(pathB);

            var pointsA = new Plotter(commandSequenceA).GetPoints();
            var pointsB = new Plotter(commandSequenceB).GetPoints();

            //var intersections = pointsA.Intersect(pointsB).Where(o => o.Distance > 0);
            var intersections = FindIntersections(pointsA, pointsB);
            ClosestIntersection = intersections.OrderBy(o => o.Distance).First(o => o.Distance > 0);
            FewestSteps = intersections.OrderBy(o => o.Steps).First(o => o.Steps > 0);
        }

        private IList<Point> FindIntersections(IList<Point> pointsA, IList<Point> pointsB)
        {
            var dictionary = new Dictionary<string, Point>();
            var intersections = new List<Point>();
            foreach (var pointA in pointsA)
            {
                if(!dictionary.ContainsKey(pointA.Id))
                    dictionary.Add(pointA.Id, pointA);
            }
            foreach (var pointB in pointsB)
            {
                if (dictionary.ContainsKey(pointB.Id))
                {
                    var pointA = dictionary.GetValueOrDefault(pointB.Id);
                    var intersectionPoint = new Point(pointA!.X, pointA.Y, pointA.Steps + pointB.Steps);
                    intersections.Add(intersectionPoint);
                }
            }
            return intersections;
        }
        
        private IList<Command> GetCommands(string path)
        {
            return path.Split(',').Select(CommandFactory.Create).ToList();
        }
    }
    
    public abstract class Command
    {
        private readonly int _distance;

        protected Command(int distance)
        {
            _distance = distance;
        }

        protected abstract Point Move(Point lastPoint);

        public IList<Point> Execute(Point fromPoint)
        {
            var points = new List<Point>();
            var lastPoint = fromPoint;
            for (var i = 1; i <= _distance; i++)
            {
                var point = Move(lastPoint);
                points.Add(point);
                lastPoint = point;
            }
            return points;
        }
    }
    
    public static class CommandFactory
    {
        public static Command Create(string command)
        {
            var direction = command[0];
            var distance = GetDistance(command);
            if (direction == 'U')
                return new UpCommand(distance);
            if (direction == 'R')
                return new RightCommand(distance);
            if (direction == 'D')
                return new DownCommand(distance);
            if (direction == 'L')
                return new LeftCommand(distance);
            throw new UnknownDirectionException(direction);
        }

        private static int GetDistance(string command)
        {
            var distance = command.Substring(1);
            return int.Parse(distance);
        }
    }
    
    public class UpCommand(int distance) : Command(distance)
    {
        protected override Point Move(Point lastPoint) => 
            new(lastPoint.X, lastPoint.Y + 1, lastPoint.Steps + 1);
    }
    
    public class RightCommand(int distance) : Command(distance)
    {
        protected override Point Move(Point lastPoint) => 
            new(lastPoint.X + 1, lastPoint.Y, lastPoint.Steps + 1);
    }
    
    public class DownCommand(int distance) : Command(distance)
    {
        protected override Point Move(Point lastPoint) => 
            new(lastPoint.X, lastPoint.Y - 1, lastPoint.Steps + 1);
    }
    
    public class LeftCommand(int distance) : Command(distance)
    {
        protected override Point Move(Point lastPoint) => 
            new(lastPoint.X - 1, lastPoint.Y, lastPoint.Steps + 1);
    }
    
    public class Plotter
    {
        private readonly IList<Command> _commands;

        public Plotter(IList<Command> commands)
        {
            _commands = commands;
        }

        public IList<Point> GetPoints()
        {
            var points = new List<Point> {new Point(0, 0, 0)};
            foreach (var command in _commands)
            {
                var commandPoints = command.Execute(points.Last());
                points.AddRange(commandPoints);
            }

            return points;
        }
    }
    
    public class Point : IEquatable<Point>
    {
        public int X { get; }
        public int Y { get; }
        public string Id { get; }
        public int Steps { get; }

        public Point(int x, int y, int steps)
        {
            X = x;
            Y = y;
            Id = $"{X}|{Y}";
            Steps = steps;
        }

        public int Distance => Math.Abs(X) + Math.Abs(Y);

        public bool Equals(Point? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }
    }
    
    public class UnknownDirectionException : Exception
    {
        public UnknownDirectionException(char direction)
            : base($"Unknown direction: {direction}")
        {
        }
    }
}