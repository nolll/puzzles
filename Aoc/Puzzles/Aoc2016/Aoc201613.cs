using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("A Maze of Twisty Little Cubicles")]
public class Aoc201613 : AocPuzzle
{
    [Puzzle("7cedb689517199a6fa49637072deb141")]
    public int Part1(string input) => StepCountToTarget(50, 50, int.Parse(input), 31, 39);

    [Puzzle("d8ee6b0475f3971b598eab03bf31bed4")]
    public int Part2(string input) => LocationCountAfter(75, 75, int.Parse(input), 50);

    public int StepCountToTarget(int width, int height, int secretNumber, int targetX, int targetY)
    {
        var grid = BuildGrid(width, height, secretNumber);
        return PathFinder.ShortestPathTo(grid, new Coord(1, 1), new Coord(targetX, targetY)).Count();
    }

    public int LocationCountAfter(int width, int height, int secretNumber, int steps) =>
        LocationCountAfter(width, height, secretNumber, new Coord(1, 1), steps);

    private int LocationCountAfter(int width, int height, int secretNumber, Coord from, int steps)
    {
        var grid = BuildGrid(width, height, secretNumber);
        var queue = new List<Coord> { from };
        var i = 0;
        while (i <= steps)
        {
            var newQueue = new List<Coord>();
            foreach (var coord in queue)
            {
                grid.MoveTo(coord);
                grid.WriteValue('O');
                var adjacentCoords = grid.OrthogonalAdjacentCoords.Where(o => grid.ReadValueAt(o) == '.').ToList();
                newQueue.AddRange(adjacentCoords);
            }

            queue = newQueue;
            i++;
        }

        return grid.Values.Count(o => o == 'O');
    }

    private static Grid<char> BuildGrid(in int width, in int height, in int secretNumber)
    {
        var grid = new Grid<char>(width, height);
        foreach (var coord in grid.Coords)
        {
            var (x, y) = coord;
            var value = x * x + 3 * x + 2 * x * y + y + y * y + secretNumber;
            var binary = Convert.ToString(value, 2);
            var numberOfSetBits = binary.Count(o => o == '1');
            var isOpenSpace = numberOfSetBits % 2 == 0;
            var c = isOpenSpace ? '.' : '#';
            grid.WriteValueAt(coord, c);
        }
        
        return grid;
    }
}