using Core.Tools;

namespace Core.TwoFactorAuth
{
    public class ScreenSimulatorRotateColumnInstruction : IScreenSimulatorInstruction
    {
        private readonly Matrix<char> _matrix;
        private readonly int _column;
        private readonly int _steps;

        public ScreenSimulatorRotateColumnInstruction(Matrix<char> matrix, int column, int steps)
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

                _matrix.MoveTo(x, y);
                newCol[newy] = _matrix.ReadValue();
            }

            for (var y = 0; y < _matrix.Height; y++)
            {
                _matrix.MoveTo(x, y);
                _matrix.WriteValue(newCol[y]);
            }
        }
    }
}