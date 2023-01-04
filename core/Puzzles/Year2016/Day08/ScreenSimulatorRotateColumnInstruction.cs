using Core.Common.CoordinateSystems.CoordinateSystem2D;

namespace Core.Puzzles.Year2016.Day08;

public class ScreenSimulatorRotateColumnInstruction : IScreenSimulatorInstruction
{
    private readonly IMatrix<char> _matrix;
    private readonly int _column;
    private readonly int _steps;

    public ScreenSimulatorRotateColumnInstruction(IMatrix<char> matrix, int column, int steps)
    {
        _matrix = matrix;
        _column = column;
        _steps = steps;
    }

    public void Execute()
    {
        var x = _column;
        var newCol = new char[_matrix.Height];
        for (var y = 0; y < _matrix.Height; y++)
        {
            var newy = y + _steps;
            if (newy < 0)
                newy += _matrix.Height;

            if (newy >= _matrix.Height)
                newy -= _matrix.Height;

            newCol[newy] = _matrix.ReadValueAt(x, y);
        }

        for (var y = 0; y < _matrix.Height; y++)
        {
            _matrix.WriteValueAt(x, y, newCol[y]);
        }
    }
}