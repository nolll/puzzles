using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201614;

[IsSlow] // 16s for part 2
[Name("One-Time Pad")]
[Comment("Slow hashing")]
public class Aoc201614 : AocPuzzle
{
    [Puzzle("ab424c3c48235af9c7eadd8da2414dea")]
    public int Part1(string input) => new KeyGenerator(0).GetIndexOfNThKey(input, 64);

    [Puzzle("f84f1a02e789615187ec700dcf71ab79")]
    public int Part2(string input) => new KeyGenerator(2016).GetIndexOfNThKey(input, 64);
}