using System.Collections.Generic;
using System.Linq;

namespace App.Puzzles.Year2019.Day03;

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
                var intersectionPoint = new Point(pointA.X, pointA.Y, pointA.Steps + pointB.Steps);
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