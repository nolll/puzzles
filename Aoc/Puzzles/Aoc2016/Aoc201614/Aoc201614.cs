﻿using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201614;

[IsSlow] // 26s for part 2
[Name("One-Time Pad")]
[Comment("Slow hashing")]
public class Aoc201614(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var generator = new KeyGenerator();
        var index = generator.GetIndexOfNThKey(input, 64, 0);
            
        return new PuzzleResult(index, "ab424c3c48235af9c7eadd8da2414dea");
    }

    protected override PuzzleResult RunPart2()
    {
        var generator = new KeyGenerator();
        var index = generator.GetIndexOfNThKey(input, 64, 2016);
            
        return new PuzzleResult(index, "f84f1a02e789615187ec700dcf71ab79");
    }
}