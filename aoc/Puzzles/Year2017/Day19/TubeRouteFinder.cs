using System.Linq;
using System.Text;
using common.CoordinateSystems.CoordinateSystem2D;

namespace Aoc.Puzzles.Year2017.Day19;

public class TubeRouteFinder
{
    private readonly Matrix<char> _matrix;

    private const char Space = ' ';
    private const char Empty = '.';
    private const char Vertical = '|';
    private const char Horizontal = '-';
    private const char Plus = '+';

    public string Route { get; private set; }
    public int StepCount { get; private set; }

    public TubeRouteFinder(string input)
    {
        var adjustedInput = input.Replace(Space, Empty);
        _matrix = MatrixBuilder.BuildCharMatrix(adjustedInput);
        var y = 0;
        var x = _matrix.Values.ToList().IndexOf(Vertical);
        _matrix.MoveTo(x, y);
        _matrix.TurnTo(MatrixDirection.Down);
    }

    public void FindRoute()
    {
        var route = new StringBuilder();
        while (true)
        {
            var val = _matrix.ReadValue();

            if (val == Empty) { 
                break;
            }

            StepCount++;

            if (val == Vertical || val == Horizontal)
            {
                _matrix.MoveForward();
                continue;
            }

            if (val == Plus)
            {
                _matrix.TurnLeft();
                _matrix.MoveForward();
                var invalidChar = _matrix.Direction.Equals(MatrixDirection.Left) || _matrix.Direction.Equals(MatrixDirection.Right)
                    ? Vertical
                    : Horizontal;

                var tempVal = _matrix.ReadValue();
                if (tempVal == invalidChar || tempVal == Empty)
                {
                    _matrix.MoveBackward();
                    _matrix.TurnLeft();
                    _matrix.TurnLeft();
                }
                else
                {
                    _matrix.MoveBackward();
                }

                _matrix.MoveForward();
                continue;
            }

            route.Append(val);
            _matrix.MoveForward();
        }

        Route = route.ToString();
    }
}