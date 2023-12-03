using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2015.Aoc201518;

public class Aoc201518 : AocPuzzle
{
    public override string Name => "Like a GIF For Your Yard";

    protected override PuzzleResult RunPart1()
    {
        var gif = new AnimatedGif(InputFile);
        gif.RunAnimation(100);
        return new PuzzleResult(gif.LightCount, "cf54372c819da8af501619293a164f4f");
    }

    protected override PuzzleResult RunPart2()
    {
        var gif = new AnimatedGif(InputFile, true);
        gif.RunAnimation(100);
        return new PuzzleResult(gif.LightCount, "91a84e73c4b0d0185f19367fdc75f4a7");
    }
}