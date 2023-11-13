using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2016.Aoc201614;

public class Aoc201614 : AocPuzzle
{
    public override string Name => "One-Time Pad";

    public override string Comment => "Slow hashing";
    public override bool IsSlow => true; // 26s for part 2

    protected override PuzzleResult RunPart1()
    {
        var generator = new KeyGenerator();
        var index = generator.GetIndexOfNThKey(Input, 64, 0);
            
        return new PuzzleResult(index, "ab424c3c48235af9c7eadd8da2414dea");
    }

    protected override PuzzleResult RunPart2()
    {
        var generator = new KeyGenerator();
        var index = generator.GetIndexOfNThKey(Input, 64, 2016);
            
        return new PuzzleResult(index, "f84f1a02e789615187ec700dcf71ab79");
    }

    private static string Input => "zpqevtbw";
}