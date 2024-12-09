using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202409;

[Name("")]
public class Aoc202409 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var nums = input.ToCharArray().Select(o => int.Parse(o.ToString())).ToArray();
        var blocks = new int[nums.Sum()];

        var b = 0;
        var isFile = true;
        for (var i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums[i]; j++)
            {
                blocks[b] = isFile ? i / 2 : -1;
                b++;
            }

            isFile = !isFile;
        }

        var f = 0;
        var r = blocks.Length - 1;

        while (f < r)
        {
            if (blocks[f] > -1)
            {
                f++;
                continue;
            }

            if (blocks[r] == -1)
            {
                r--;
                continue;
            }

            blocks[f] = blocks[r];
            blocks[r] = -1;
            f++;
            r--;
        }

        var checksum = 0L;
        for (var a = 0; a < blocks.Length; a++)
        {
            var v = blocks[a];
            if (v > -1)
                checksum += a * v;
        }
        
        return new PuzzleResult(checksum, "4ca7aa30f44261b47440a1e8e3647d44");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }
}