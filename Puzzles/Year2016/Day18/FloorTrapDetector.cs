using System.Linq;

namespace Aoc.Puzzles.Year2016.Day18;

public class FloorTrapDetector
{
    private readonly string _input;
    private const char Safe = '.';
    private const char Trap = '^'; 

    public FloorTrapDetector(string input)
    {
        _input = input;
    }

    public int CountSafeTiles(int rows)
    {
        var y = 1;
        var lastRow = _input.ToCharArray();
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