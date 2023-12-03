using Puzzles.Common.CoordinateSystems.CoordinateSystem2D;

namespace Puzzles.Aoc.Puzzles.Aoc2016.Aoc201608;

public class ScreenSimulatorRectInstruction : IScreenSimulatorInstruction
{
    private readonly Matrix<char> _matrix;
    private readonly int _width;
    private readonly int _height;

    public ScreenSimulatorRectInstruction(Matrix<char> matrix, int width, int height)
    {
        _matrix = matrix;
        _width = width;
        _height = height;
    }

    public void Execute()
    {
        for (var y = 0; y < _height; y++)
        {
            for (var x = 0; x < _width; x++)
            {
                _matrix.WriteValueAt(x, y, '#');
            }
        }
    }
}