using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Like a Rogue")]
public class Aoc201618 : AocPuzzle
{
    [Puzzle("e5a7af4db610ffe95694d0dd5d7b43c6")]
    public int Part1(string input) => new FloorTrapDetector(input).CountSafeTiles(40);

    [Puzzle("bd1b0d5a17ef0a0b7c880a805ea95cc4")]
    public int Part2(string input) => new FloorTrapDetector(input).CountSafeTiles(400_000);
    
    public class FloorTrapDetector(string input)
    {
        private const char Safe = '.';
        private const char Trap = '^';

        public int CountSafeTiles(int rows)
        {
            var y = 1;
            var lastRow = input.ToCharArray();
            var safeCount = lastRow.Count(o => o == Safe);
            while (y < rows)
            {
                var nextRow = new char[lastRow.Length];
                for (var x = 0; x < lastRow.Length; x++)
                {
                    var c = IsCurrentTileATrap(lastRow, x) ? Trap : Safe;
                    nextRow[x] = c;
                }

                safeCount += nextRow.Count(o => o == Safe);
                lastRow = nextRow;
                y++;
            }

            return safeCount;
        }

        private static bool IsCurrentTileATrap(char[] lastRow, int pos)
        {
            var leftIsTrap = pos > 0 && lastRow[pos - 1] == Trap;
            var rightIsTrap = pos < (lastRow.Length - 1) && lastRow[pos + 1] == Trap;

            return leftIsTrap && !rightIsTrap || rightIsTrap && !leftIsTrap;
        }
    }
}