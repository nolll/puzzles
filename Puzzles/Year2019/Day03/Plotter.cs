using System.Collections.Generic;
using System.Linq;

namespace Aoc.Puzzles.Year2019.Day03;

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