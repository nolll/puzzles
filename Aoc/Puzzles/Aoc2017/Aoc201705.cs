using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("A Maze of Twisty Trampolines, All Alike")]
public class Aoc201705 : AocPuzzle
{
    [Puzzle("3893f5208a5bb1ed3716ffb10c7074d1")]
    public int Part1(string input) => Solve(input, GetChangePart1);

    [Puzzle("e9b390d2f610956da9f592bc52c789cc")]
    public int Part2(string input) => Solve(input, GetChangePart2);

    private static int Solve(string input, Func<int, int> getChange)
    {
        var index = 0;
        var stepCount = 0;
        var numbers = Parse(input);
        while (IsInRange(numbers, index))
        {
            var val = numbers[index];
            numbers[index] = val + getChange(val);
            index += val;
            stepCount += 1;
        }
            
        return stepCount;
    }

    private static int GetChangePart1(int _) => 1;
    private static int GetChangePart2(int val) => val >= 3 ? -1 : 1;
    private static bool IsInRange(int[] numbers, int index) => index >= 0 && index < numbers.Length;
        
    private static int[] Parse(string input) =>
        [.. input.Trim().Split(LineBreaks.Single).Select(o => int.Parse(o.Trim()))];
}