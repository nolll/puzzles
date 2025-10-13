using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201608;

public class ScreenSimulatorRotateRowInstruction : IScreenSimulatorInstruction
{
    private readonly Grid<char> _grid;
    private readonly int _row;
    private readonly int _steps;

    public ScreenSimulatorRotateRowInstruction(Grid<char> grid, int row, int steps)
    {
        _grid = grid;
        _row = row;
        _steps = steps;
    }

    public void Execute()
    {
        var y = _row;
        var newRow = new char[_grid.Width];
        for (var x = 0; x < _grid.Width; x++)
        {
            var newX = x + _steps;
            if (newX < 0)
                newX += _grid.Width;

            if (newX >= _grid.Width)
                newX -= _grid.Width;

            newRow[newX] = _grid.ReadValueAt(x, y);
        }

        for (var x = 0; x < _grid.Width; x++)
        {
            _grid.WriteValueAt(x, y, newRow[x]);
        }
    }
}