using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202502;

[Name("Rollercoaster Heights")]
public class FlipFlop202502 : FlipFlopPuzzle
{
    public PuzzleResult Part1(string input) => 
        new(Solve(input, sequenceLength => sequenceLength), "a108ed87069fbb10b6d6595e8795dc16");

    public PuzzleResult Part2(string input) => 
        new(Solve(input, sequenceLength => Enumerable.Range(1, sequenceLength).Sum()), "3d520917bed77059dbbb4bf1f7433ffa");

    public PuzzleResult Part3(string input) => 
        new(Solve(input, sequenceLength => Numbers.Fibonacci(sequenceLength)), "9116cf946c0d82e0d08bffc0da078dd1");

    private static long Solve(string input, Func<int, long> heightDelta)
    {
        var sequenceLengths = GetSequenceLengths(input);
        var initialDirection = input.First() == '^' ? 1 : -1;
        return GetBestHeight(sequenceLengths, initialDirection, heightDelta);
    }

    private static IEnumerable<int> GetSequenceLengths(string input)
    {
        var chars = input.ToCharArray();
        var length = 1;
        for (var i = 1; i < chars.Length; i++)
        {
            if (input[i] != input[i - 1])
            {
                yield return length;
                length = 0;
            }

            length++;
        }

        yield return length;
    }

    private static long GetBestHeight(IEnumerable<int> sequences, int direction, Func<int, long> heightDelta)
    {
        var best = 0L;
        var height = 0L;
        foreach (var sequence in sequences)
        {
            height += direction * heightDelta(sequence);
            best = Math.Max(best, height);
            direction *= -1;
        }

        return best;
    }
}