using System.Linq;
using Core.Tools;

namespace Core.Lumber
{
    public class LumberCollection
    {
        private const char Open = '.';
        private const char Wood = '|';
        private const char Lumber = '#';

        private Matrix<char> _matrix;
        private int LumberCount => _matrix.Values.Count(o => o == Lumber);
        private int WoodCount => _matrix.Values.Count(o => o == Wood);
        public int ResourceValue => LumberCount * WoodCount;

        public LumberCollection(string input)
        {
            _matrix = MatrixBuilder.BuildCharMatrix(input);
        }

        public void Run(int minutes)
        {
            for (var i = 0; i < minutes; i++)
            {
                _matrix = GetNextIteration();
            }
        }

        private Matrix<char> GetNextIteration()
        {
            var newMatrix = new Matrix<char>();
            for (var y = 0; y < _matrix.Height; y++)
            {
                for (var x = 0; x < _matrix.Width; x++)
                {
                    _matrix.MoveTo(x, y);
                    newMatrix.MoveTo(x, y);
                    newMatrix.WriteValue(GetNewValue());
                }
            }
            return newMatrix;
        }

        private char GetNewValue()
        {
            var adjacent = _matrix.Adjacent8;
            var currentValue = _matrix.ReadValue();
            if (currentValue == Open)
            {
                return adjacent.Count(o => o == Wood) >= 3 ? Wood : currentValue;
            }
            if (currentValue == Wood)
            {
                return adjacent.Count(o => o == Lumber) >= 3 ? Lumber : currentValue;
            }
            if (currentValue == Lumber)
            {
                return adjacent.Count(o => o == Lumber) >= 1 && adjacent.Count(o => o == Wood) >= 1 ? Lumber : Open;
            }

            return Open;
        }
    }
}