using System.Text;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201719;

public class TubeRouteFinder
{
    private readonly Grid<char> _grid;

    private const char Space = ' ';
    private const char Empty = '.';
    private const char Vertical = '|';
    private const char Horizontal = '-';
    private const char Plus = '+';

    public string? Route { get; private set; }
    public int StepCount { get; private set; }

    public TubeRouteFinder(string input)
    {
        var adjustedInput = input.Replace(Space, Empty);
        _grid = GridBuilder.BuildCharGrid(adjustedInput);
        var y = 0;
        var x = _grid.Values.ToList().IndexOf(Vertical);
        _grid.MoveTo(x, y);
        _grid.TurnTo(GridDirection.Down);
    }

    public void FindRoute()
    {
        var route = new StringBuilder();
        while (true)
        {
            var val = _grid.ReadValue();

            if (val == Empty) { 
                break;
            }

            StepCount++;

            if (val == Vertical || val == Horizontal)
            {
                _grid.MoveForward();
                continue;
            }

            if (val == Plus)
            {
                _grid.TurnLeft();
                _grid.MoveForward();
                var invalidChar = _grid.Direction.Equals(GridDirection.Left) || _grid.Direction.Equals(GridDirection.Right)
                    ? Vertical
                    : Horizontal;

                var tempVal = _grid.ReadValue();
                if (tempVal == invalidChar || tempVal == Empty)
                {
                    _grid.MoveBackward();
                    _grid.TurnLeft();
                    _grid.TurnLeft();
                }
                else
                {
                    _grid.MoveBackward();
                }

                _grid.MoveForward();
                continue;
            }

            route.Append(val);
            _grid.MoveForward();
        }

        Route = route.ToString();
    }
}