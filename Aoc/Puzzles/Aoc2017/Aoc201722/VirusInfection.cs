using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201722;

public class VirusInfection
{
    private const char Clean = '.';
    private const char Weakened = 'W';
    private const char Infected = '#';
    private const char Flagged = 'F';

    private readonly Grid<char> _grid;

    public VirusInfection(string input)
    {
        _grid = GridBuilder.BuildCharGrid(input, '.');

        var x = (_grid.Width - 1) / 2;
        var y = (_grid.Height - 1) / 2;
        _grid.MoveTo(x, y);
        _grid.TurnTo(GridDirection.Up);
    }

    public int RunPart1(int iterations)
    {
        var infectionCount = 0;
        for (var i = 0; i < iterations; i++)
        {
            var val = _grid.ReadValue();
            if (val == Infected)
            {
                _grid.TurnRight();
                _grid.WriteValue(Clean);
            }
            else
            {
                _grid.TurnLeft();
                _grid.WriteValue(Infected);
                infectionCount++;
            }

            _grid.MoveForward();
        }

        return infectionCount;
    }

    public int RunPart2(int iterations)
    {
        var infectionCount = 0;
        for (var i = 0; i < iterations; i++)
        {
            var val = _grid.ReadValue();
            if (val == Clean)
            {
                _grid.TurnLeft();
                _grid.WriteValue(Weakened);
            }
            else if(val == Weakened)
            {
                _grid.WriteValue(Infected);
                infectionCount++;
            }
            else if (val == Infected)
            {
                _grid.TurnRight();
                _grid.WriteValue(Flagged);
            }
            else
            {
                _grid.TurnRight();
                _grid.TurnRight();
                _grid.WriteValue(Clean);
            }

            _grid.MoveForward();
        }

        return infectionCount;
    }
}