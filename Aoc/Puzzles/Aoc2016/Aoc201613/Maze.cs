using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201613;

public class Maze(int width, int height, int secretNumber)
{
    private readonly Grid<char> _grid = BuildMatrix(width, height, secretNumber);

    public int StepCountToTarget(int targetX, int targetY) =>
        PathFinder.ShortestPathTo(_grid, new Coord(1, 1), new Coord(targetX, targetY)).Count;
    
    public int LocationCountAfter(int steps) => LocationCountAfter(new Coord(1, 1), steps);

    private int LocationCountAfter(Coord from, int steps)
    {
        var queue = new List<Coord> { from };
        var i = 0;
        while (i <= steps)
        {
            var newQueue = new List<Coord>();
            foreach (var coord in queue)
            {
                _grid.MoveTo(coord);
                _grid.WriteValue('O');
                var adjacentCoords = _grid.OrthogonalAdjacentCoords.Where(o => _grid.ReadValueAt(o) == '.').ToList();
                newQueue.AddRange(adjacentCoords);
            }

            queue = newQueue;
            i++;
        }

        return _grid.Values.Count(o => o == 'O');
    }

    private static Grid<char> BuildMatrix(in int width, in int height, in int secretNumber)
    {
        var matrix = new Grid<char>();
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var value = x * x + 3 * x + 2 * x * y + y + y * y + secretNumber;
                var binary = Convert.ToString(value, 2);
                var numberOfSetBits = binary.Count(o => o == '1');
                var isOpenSpace = numberOfSetBits % 2 == 0;
                var c = isOpenSpace ? '.' : '#';
                matrix.WriteValueAt(x, y, c);
            }
        }

        return matrix;
    }
}