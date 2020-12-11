using System.Linq;
using Core.Tools;

namespace Core.WaitingAreaSeating
{
    public class SeatingSimulator
    {
        private Matrix<char> _matrix;
        public int OccupiedSeatCount { get; private set; }

        public SeatingSimulator(string input)
        {
            _matrix = MatrixBuilder.BuildCharMatrix(input);
        }

        public void Run(int iterations)
        {
            for (var i = 0; i < iterations; i++)
            {
                Run();
            }
        }

        public void RunUntilStable()
        {
            var prevCount = 0;
            var currentCount = -1;
            while (prevCount != currentCount)
            {
                prevCount = currentCount;
                Run();
                currentCount = _matrix.Values.Count(o => o == '#');
            }

            OccupiedSeatCount = currentCount;
        }

        public void Run()
        {
            var newMatrix = _matrix.Copy();
            for (var y = 0; y < _matrix.Height; y++)
            {
                for (var x = 0; x < _matrix.Width; x++)
                {
                    _matrix.MoveTo(x, y);
                    var currentValue = _matrix.ReadValue();
                    var adjacentValues = _matrix.Adjacent8;
                    var neighborCount = adjacentValues.Count(o => o == '#');
                    var newValue = GetNewValue(currentValue, neighborCount);

                    newMatrix.MoveTo(x, y);
                    newMatrix.WriteValue(newValue);
                }
            }
            _matrix = newMatrix;
        }

        private char GetNewValue(char currentValue, int neighborCount)
        {
            if (currentValue == 'L' && neighborCount == 0)
                return '#';

            if (currentValue == '#' && neighborCount >= 4)
                return 'L';

            return currentValue;
        }
    }
}