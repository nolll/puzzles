using System.Collections.Generic;
using System.Linq;

namespace Core.IntersectionFinder
{
    public class IntersectionFinder
    {
        public Point ClosestIntersection { get; }

        public IntersectionFinder(string pathA, string pathB)
        {
            var commandSequenceA = GetCommands(pathA);
            var commandSequenceB = GetCommands(pathB);

            var pointsA = new Plotter(commandSequenceA).GetPoints();
            var pointsB = new Plotter(commandSequenceB).GetPoints();

            var intersections = FindIntersections(pointsA, pointsB);
            ClosestIntersection = intersections.OrderBy(o => o.Distance).First();
        }

        private IList<Point> FindIntersections(IList<Point> pointsA, IList<Point> pointsB)
        {
            var intersections = new List<Point>();
            foreach (var a in pointsA)
            {
                foreach (var b in pointsB)
                {
                    if (a.X == b.X && a.Y == b.Y)
                        intersections.Add(a);
                }
            }
            return intersections.Where(o => o.Distance > 0).ToList();
        }

        private IList<Command> GetCommands(string path)
        {
            return path.Split(',').Select(CommandFactory.Create).ToList();
        }
    }
}