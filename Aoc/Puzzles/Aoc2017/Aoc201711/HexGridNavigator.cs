using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201711;

public class HexGridNavigator
{
    private readonly Grid<int> _grid;
    public int EndDistance { get; }
    public int MaxDistance { get; }

    public HexGridNavigator(string input)
    {
        _grid = new Grid<int>();
        _grid.TurnTo(GridDirection.Up);

        var directions = input.Split(',');
        var maxDistance = 0;
        var currentDistance = 0;

        foreach (var direction in directions)
        {
            Move(direction);
            currentDistance = Distance;
            if(currentDistance > maxDistance)
                maxDistance = currentDistance;
        }

        EndDistance = currentDistance;
        MaxDistance = maxDistance;
    }

    private int Distance
    {
        get
        {
            var x = _grid.Coord.X;
            var y = _grid.Coord.Y;
            var xStart = _grid.StartCoord.X;
            var yStart = _grid.StartCoord.Y;
            var xMax = Math.Max(xStart, x);
            var xMin = Math.Min(xStart, x);
            var yMax = Math.Max(yStart, y);
            var yMin = Math.Min(yStart, y);
            var xDistance = xMax - xMin;
            var yDistance = yMax - yMin;
            var distance = 0;

            while (xDistance > 0 && yDistance > 0)
            {
                xDistance--;
                yDistance--;
                distance++;
            }

            while (xDistance > 0)
            {
                xDistance--;
                distance++;
            }

            while (yDistance > 0)
            {
                yDistance--;
                yDistance--;
                distance++;
            }

            return distance;
        }
    }

    private void Move(string direction)
    {
        if (direction == "n")
        {
            _grid.MoveUp();
            _grid.MoveUp();
        }
        else if (direction == "ne")
        {
            _grid.MoveRight();
            _grid.MoveUp();
        }
        else if (direction == "se")
        {
            _grid.MoveRight();
            _grid.MoveDown();
        }
        else if (direction == "s")
        {
            _grid.MoveDown();
            _grid.MoveDown();
        }
        else if (direction == "sw")
        {
            _grid.MoveLeft();
            _grid.MoveDown();
        }
        else if (direction == "nw")
        {
            _grid.MoveLeft();
            _grid.MoveUp();
        }
    }
}