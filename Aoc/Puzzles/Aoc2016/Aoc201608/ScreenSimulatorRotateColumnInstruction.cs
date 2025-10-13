using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201608;

public class ScreenSimulatorRotateColumnInstruction : IScreenSimulatorInstruction
{
    private readonly Grid<char> _grid;
    private readonly int _column;
    private readonly int _steps;

    public ScreenSimulatorRotateColumnInstruction(Grid<char> grid, int column, int steps)
    {
        _grid = grid;
        _column = column;
        _steps = steps;
    }

    public void Execute()
    {
        var x = _column;
        var newCol = new char[_grid.Height];
        for (var y = 0; y < _grid.Height; y++)
        {
            var newy = y + _steps;
            if (newy < 0)
                newy += _grid.Height;

            if (newy >= _grid.Height)
                newy -= _grid.Height;

            newCol[newy] = _grid.ReadValueAt(x, y);
        }

        for (var y = 0; y < _grid.Height; y++)
        {
            _grid.WriteValueAt(x, y, newCol[y]);
        }
    }
}