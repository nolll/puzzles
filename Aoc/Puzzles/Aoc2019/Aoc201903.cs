using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Crossed Wires")]
public class Aoc201903 : AocPuzzle
{
    [Puzzle("3dbd15d37a682cfa1ca55525a248c184")]
    public int Part1(string input)
    {
        var intersections = FindIntersections(input);
        return intersections.OrderBy(o => o.Distance).First(o => o.Distance > 0).Distance;
    }

    [Puzzle("51670676a41763c6093416dd009a8ba6")]
    public int Part2(string input)
    {
        var intersections = FindIntersections(input);
        return intersections.OrderBy(o => o.Steps).First(o => o.Steps > 0).Steps;
    }
    
    private IList<Point> FindIntersections(string input)
    {
        var (a, b) = input.Split(LineBreaks.Single);
        var commandSequenceA = GetCommands(a);
        var commandSequenceB = GetCommands(b);

        var pointsA = new Plotter(commandSequenceA).GetPoints();
        var pointsB = new Plotter(commandSequenceB).GetPoints();

        return FindIntersections(pointsA, pointsB);
    }

    private IList<Point> FindIntersections(IList<Point> pointsA, IList<Point> pointsB)
    {
        var dictionary = new Dictionary<string, Point>();
        var intersections = new List<Point>();
        foreach (var pointA in pointsA)
        {
            dictionary.TryAdd(pointA.Id, pointA);
        }

        foreach (var pointB in pointsB)
        {
            if (!dictionary.ContainsKey(pointB.Id))
                continue;
            
            var pointA = dictionary.GetValueOrDefault(pointB.Id);
            var intersectionPoint = new Point(pointA!.X, pointA.Y, pointA.Steps + pointB.Steps);
            intersections.Add(intersectionPoint);
        }

        return intersections;
    }

    private static IList<Command> GetCommands(string path) => path.Split(',').Select(CommandFactory.Create).ToList();

    public abstract class Command(int distance)
    {
        protected abstract Point Move(Point lastPoint);

        public IList<Point> Execute(Point fromPoint)
        {
            var points = new List<Point>();
            var lastPoint = fromPoint;
            for (var i = 1; i <= distance; i++)
            {
                var point = Move(lastPoint);
                points.Add(point);
                lastPoint = point;
            }

            return points;
        }
    }

    private static class CommandFactory
    {
        public static Command Create(string command) => Create(command[0], GetDistance(command));

        private static Command Create(char direction, int distance) => direction switch
        {
            'U' => new UpCommand(distance),
            'R' => new RightCommand(distance),
            'D' => new DownCommand(distance),
            _ => new LeftCommand(distance)
        };

        private static int GetDistance(string command) => int.Parse(command[1..]);
    }

    private class UpCommand(int distance) : Command(distance)
    {
        protected override Point Move(Point lastPoint) => new(lastPoint.X, lastPoint.Y + 1, lastPoint.Steps + 1);
    }

    private class RightCommand(int distance) : Command(distance)
    {
        protected override Point Move(Point lastPoint) => new(lastPoint.X + 1, lastPoint.Y, lastPoint.Steps + 1);
    }

    private class DownCommand(int distance) : Command(distance)
    {
        protected override Point Move(Point lastPoint) => new(lastPoint.X, lastPoint.Y - 1, lastPoint.Steps + 1);
    }

    private class LeftCommand(int distance) : Command(distance)
    {
        protected override Point Move(Point lastPoint) => new(lastPoint.X - 1, lastPoint.Y, lastPoint.Steps + 1);
    }

    private class Plotter(IList<Command> commands)
    {
        public IList<Point> GetPoints()
        {
            var points = new List<Point> { new(0, 0, 0) };
            foreach (var command in commands)
            {
                var commandPoints = command.Execute(points.Last());
                points.AddRange(commandPoints);
            }

            return points;
        }
    }

    public record Point(int X, int Y, int Steps)
    {
        public string Id { get; } = $"{X}|{Y}";
        public int Distance => Math.Abs(X) + Math.Abs(Y);
    }
}