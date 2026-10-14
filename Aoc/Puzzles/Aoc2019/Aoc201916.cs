using System.Text;
using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Flawed Frequency Transmission")]
public class Aoc201916 : AocPuzzle
{
    [Puzzle("e995b448fd31fb067432b47f11ac0e67")]
    public string Part1(string input) => SolvePart1(input, 100);

    [Puzzle("0b00b51e4f1b1d517a2bb16008f7af58")]
    public string Part2(string input) => SolvePart2(input, 100);

    private readonly int[] _basePattern = [0, 1, 0, -1];

    public string SolvePart1(string input, int phaseCount)
    {
        var list = input.ToCharArray().Select(o => int.Parse(o.ToString())).ToArray();
        for (var i = 0; i < phaseCount; i++)
        {
            list = RunPhasePart1(list);
        }

        return string.Join("", list)[..8];
    }

    private int[] RunPhasePart1(int[] inputList)
    {
        var outputList = new int[inputList.Length];
        for (var i = 0; i < inputList.Length; i++)
        {
            var patternPos = 0;
            var sum = 0;
            foreach (var val in inputList)
            {
                var calculatedPatternValue = GetPatternValue(i + 1, patternPos);
                sum += val * calculatedPatternValue;
                patternPos += 1;
            }

            outputList[i] = Math.Abs(sum % 10);
        }

        return outputList;
    }

    private int GetPatternValue(int iteration, int patternPos)
    {
        var pos = (int)Math.Floor((double)((patternPos + 1) % (4 * iteration)) / iteration);
        return _basePattern[pos];
    }

    public string SolvePart2(string input, int phaseCount)
    {
        var longinput = GetLongInput(input);
        var offset = int.Parse(longinput[..7].TrimStart('0'));
        var list = longinput.ToCharArray().Select(o => int.Parse(o.ToString())).Skip(offset).ToArray();
        for (var i = 0; i < phaseCount; i++)
        {
            list = RunPhasePart2(list);
        }

        return string.Join("", list)[..8];
    }

    private static int[] RunPhasePart2(int[] inputList)
    {
        var runningSum = 0;
        var outputList = new int[inputList.Length];
        for (var i = inputList.Length - 1; i >= 0; i--)
        {
            runningSum += inputList[i];
            outputList[i] = Math.Abs(runningSum % 10);
        }

        return outputList;
    }

    private static string GetLongInput(string input) => string.Concat(Enumerable.Repeat(input, 10000));
}