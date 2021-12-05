using Core.Tools;

namespace ConsoleApp.Puzzles.Year2017.Puzzles.Day22
{
    public class VirusInfection
    {
        private const char Clean = '.';
        private const char Weakened = 'W';
        private const char Infected = '#';
        private const char Flagged = 'F';

        private readonly Matrix<char> _matrix;

        public VirusInfection(string input)
        {
            _matrix = MatrixBuilder.BuildCharMatrix(input, '.');

            var x = (_matrix.Width - 1) / 2;
            var y = (_matrix.Height - 1) / 2;
            _matrix.MoveTo(x, y);
            _matrix.TurnTo(MatrixDirection.Up);
        }

        public int RunPart1(int iterations)
        {
            var infectionCount = 0;
            for (var i = 0; i < iterations; i++)
            {
                var val = _matrix.ReadValue();
                if (val == Infected)
                {
                    _matrix.TurnRight();
                    _matrix.WriteValue(Clean);
                }
                else
                {
                    _matrix.TurnLeft();
                    _matrix.WriteValue(Infected);
                    infectionCount++;
                }

                _matrix.MoveForward();
            }

            return infectionCount;
        }

        public int RunPart2(int iterations)
        {
            var infectionCount = 0;
            for (var i = 0; i < iterations; i++)
            {
                var val = _matrix.ReadValue();
                if (val == Clean)
                {
                    _matrix.TurnLeft();
                    _matrix.WriteValue(Weakened);
                }
                else if(val == Weakened)
                {
                    _matrix.WriteValue(Infected);
                    infectionCount++;
                }
                else if (val == Infected)
                {
                    _matrix.TurnRight();
                    _matrix.WriteValue(Flagged);
                }
                else
                {
                    _matrix.TurnRight();
                    _matrix.TurnRight();
                    _matrix.WriteValue(Clean);
                }

                _matrix.MoveForward();
            }

            return infectionCount;
        }
    }
}