using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201608;

public class ScreenSimulatorRectInstruction : IScreenSimulatorInstruction
{
    private readonly Grid<char> _grid;
    private readonly int _width;
    private readonly int _height;

    public ScreenSimulatorRectInstruction(Grid<char> grid, int width, int height)
    {
        _grid = grid;
        _width = width;
        _height = height;
    }

    public void Execute()
    {
        for (var y = 0; y < _height; y++)
        {
            for (var x = 0; x < _width; x++)
            {
                _grid.WriteValueAt(x, y, '#');
            }
        }
    }
}