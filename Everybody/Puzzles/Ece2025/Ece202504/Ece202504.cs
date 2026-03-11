using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202504;

[Name("Teeth of the Wind")]
public class Ece202504 : EverybodyEventPuzzle
{
    [Puzzle("eb41f6c9a8921d8fcdff38044b3bfe9d")]
    public PuzzleResult Part1(string input)
    {
        var numbers = Numbers.IntsFromString(input).ToArray();
        var result = numbers.First() * 2025 / numbers.Last();
        
        return new PuzzleResult(result);
    }

    [Puzzle("0257539e71c9dbe0dd69df3f4d79eb4f")]
    public long Part2(string input)
    {
        var numbers = Numbers.IntsFromString(input).ToArray();
        return (long)Math.Ceiling((double)numbers.Last() * 10_000_000_000_000 / numbers.First());
    }

    [Puzzle("92e07b9860871133c085a70db37ea249")]
    public long Part3(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var first = long.Parse(lines.First());
        var last = long.Parse(lines.Last());
        var multiplier = lines.Skip(1).SkipLast(1)
            .Select(o => o.Split('|').Select(long.Parse).ToArray())
            .Select(o => o.Last() / o.First())
            .Aggregate(first, (current, m) => current * m);

        return 100 * multiplier / last;
    }
}