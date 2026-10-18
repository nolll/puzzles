using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Sonar Sweep")]
public class Aoc202101 : AocPuzzle
{
    [Puzzle("ff696c9ddfc6c58065e2e08cdc35e82d")]
    public int Part1(string input) => Solve(input, false);

    [Puzzle("5c9945a8d579421d86e2b7811105be5e")]
    public int Part2(string input) => Solve(input, true);

    private static int Solve(string input, bool useSlidingWindow)
    {
        var depths = input.Split(LineBreaks.Single).Select(int.Parse).ToArray();

        var count = 0;
        var prev = 0;
        var start = useSlidingWindow ? 3 : 1;

        for (var i = start; i < depths.Length; i++)
        {
            var current = useSlidingWindow
                ? depths[i - 2] + depths[i - 1] + depths[i]
                : depths[i];

            if (current > prev)
                count++;

            prev = current;
        }

        return count;
    }
}