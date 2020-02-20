using System.Linq;
using Core.Tools;

namespace Core.FloorTraps
{
    public class FloorTrapDetector
    {
        private readonly Matrix<char> _matrix;
        private const char Safe = '.';
        private const char Trap = '^'; 
        private const int Left = 0;
        private const int Center = 1;
        private const int Right = 2;

        public int SafeCount => _matrix.Values.Count(o => o == Safe);

        public FloorTrapDetector(string input)
        {
            _matrix = BuildMatrix(input);
        }

        private Matrix<char> BuildMatrix(string input)
        {
            var chars = input.ToCharArray();
            var matrix = new Matrix<char>();

            var x = 0;
            const int y = 0;
            foreach (var c in chars)
            {
                matrix.MoveTo(x, y);
                matrix.WriteValue(c);
                x++;
            }

            return matrix;
        }

        public void FindTraps(int rows)
        {
            var y = 1;
            while (_matrix.Height < rows)
            {
                for (var x = 0; x < _matrix.Width; x++)
                {
                    var previousTiles = GetPreviousTiles(x, y);
                    _matrix.MoveTo(x, y);

                    var c = IsCurrentTileATrap(previousTiles) ? Trap : Safe;
                    _matrix.WriteValue(c);
                }

                y++;
            }
        }

        private bool IsCurrentTileATrap(char[] tiles)
        {
            var leftIsTrap = tiles[Left] == Trap;
            var centerIsTrap = tiles[Center] == Trap;
            var rightIsTrap = tiles[Right] == Trap;
            var rule1 = leftIsTrap && centerIsTrap && !rightIsTrap;
            var rule2 = !leftIsTrap && centerIsTrap && rightIsTrap;
            var rule3 = leftIsTrap && !centerIsTrap && !rightIsTrap;
            var rule4 = !leftIsTrap && !centerIsTrap && rightIsTrap;
            return rule1 || rule2 || rule3 || rule4;
        }

        private char[] GetPreviousTiles(int x, int y)
        {
            _matrix.MoveTo(x, y);
            var previousTiles = new[] { Safe, Safe, Safe };
            if (!_matrix.IsAtLeftEdge)
                previousTiles[Left] = _matrix.ReadValueAt(x - 1, y - 1);

            previousTiles[Center] = _matrix.ReadValueAt(x, y - 1);

            if (!_matrix.IsAtRightEdge)
                previousTiles[Right] = _matrix.ReadValueAt(x + 1, y - 1);

            return previousTiles;
        }
    }
}