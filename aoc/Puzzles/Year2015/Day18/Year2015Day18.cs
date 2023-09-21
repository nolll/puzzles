using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day18;

public class Year2015Day18 : AocPuzzle
{
    public override string Title => "Like a GIF For Your Yard";

    public override PuzzleResult RunPart1()
    {
        var gif = new AnimatedGif(FileInput);
        gif.RunAnimation(100);
        return new PuzzleResult(gif.LightCount, 821);
    }

    public override PuzzleResult RunPart2()
    {
        var gif = new AnimatedGif(FileInput, true);
        gif.RunAnimation(100);
        return new PuzzleResult(gif.LightCount, 886);
    }
}