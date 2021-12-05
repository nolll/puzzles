using Core.Tools;

namespace ConsoleApp.Years.Year2016.Puzzles.Day08
{
    public class ScreenSimulatorRotateRowInstruction : IScreenSimulatorInstruction
    {
        private readonly Matrix<char> _matrix;
        private readonly int _row;
        private readonly int _steps;

        public ScreenSimulatorRotateRowInstruction(Matrix<char> matrix, int row, int steps)
        {
            _matrix = matrix;
            _row = row;
            _steps = steps;
        }

        public void Execute()
        {
            var y = _row;
            var newRow = new char[_matrix.Width];
            for (var x = 0; x < _matrix.Width; x++)
            {
                var newX = x + _steps;
                if (newX < 0)
                    newX += _matrix.Width;

                if (newX >= _matrix.Width)
                    newX -= _matrix.Width;

                _matrix.MoveTo(x, y);
                newRow[newX] = _matrix.ReadValue();
            }

            for (var x = 0; x < _matrix.Width; x++)
            {
                _matrix.MoveTo(x, y);
                _matrix.WriteValue(newRow[x]);
            }
        }
    }
}