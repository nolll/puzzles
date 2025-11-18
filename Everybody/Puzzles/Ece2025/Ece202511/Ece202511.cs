using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202511;

[Name("The Scout Duck Protocol")]
public class Ece202511 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var cols = input.Split(LineBreaks.Single).Select(int.Parse).ToArray();
        var roundsLeft = 10;
        
        while (roundsLeft >= 0)
        {
            var moved = false;
            for (var i = 0; i < cols.Length - 1; i++)
            {
                if (cols[i] > cols[i + 1])
                {
                    cols[i]--;
                    cols[i + 1]++;
                    moved = true;
                }
            }

            roundsLeft--;

            if (!moved)
                break;
        }
        
        while (roundsLeft >= 0)
        {
            var moved = false;
            for (var i = 0; i < cols.Length - 1; i++)
            {
                if (cols[i] < cols[i + 1])
                {
                    cols[i]++;
                    cols[i + 1]--;
                    moved = true;
                }
            }

            roundsLeft--;

            if (!moved)
                break;
        }

        var checksum = 0;
        for (var i = 0; i < cols.Length; i++)
        {
            checksum += cols[i] * (i + 1);
        }
        
        return new PuzzleResult(checksum, "f8edf60eba791291edc0affdd3910b97");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}