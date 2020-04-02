using Core.Tools;

namespace Core.SporificaVirus
{
    public class VirusInfection
    {
        private const char Clean = '.';
        private const char Infected = '#';

        private readonly Matrix<char> _matrix;
        private readonly Matrix<char> _initial;

        public VirusInfection(string input)
        {
            _matrix = MatrixBuilder.BuildCharMatrix(input);
            _initial = _matrix.Copy();

            var x = (_matrix.Width - 1) / 2;
            var y = (_matrix.Height - 1) / 2;
            _matrix.MoveTo(x, y);
            _initial.MoveTo(x, y);
            _matrix.TurnTo(MatrixDirection.Up);
            _initial.TurnTo(MatrixDirection.Up);
        }

        public int Run(int iterations)
        {
            var infectionCount = 0;
            for (var i = 0; i < iterations; i++)
            {
                var val = _matrix.ReadValue();
                if (val == Infected)
                {
                    _matrix.TurnRight();
                    _initial.TurnRight();
                    _matrix.WriteValue(Clean);
                }
                else
                {
                    _matrix.TurnLeft();
                    _initial.TurnLeft();
                    _matrix.WriteValue(Infected);
                    //_initial.WriteValue(_initial.ReadValue());
                    if (_initial.ReadValue() == Clean)
                        infectionCount++;
                }

                _matrix.MoveForward();
                _initial.MoveForward();
            }

            return infectionCount;
        }
    }
}