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

            var intersections = pointsA.Intersect(pointsB).Where(o => o.Distance > 0);
            ClosestIntersection = intersections.OrderBy(o => o.Distance).First();
        }
        
        private IList<Command> GetCommands(string path)
        {
            return path.Split(',').Select(CommandFactory.Create).ToList();
        }
    }
}