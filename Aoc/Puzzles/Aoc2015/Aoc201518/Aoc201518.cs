using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201518;

[Name("Like a GIF For Your Yard")]
public class Aoc201518(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var gif = new AnimatedGif(input);
        gif.RunAnimation(100);
        return new PuzzleResult(gif.LightCount, "cf54372c819da8af501619293a164f4f");
    }

    protected override PuzzleResult RunPart2()
    {
        var gif = new AnimatedGif(input, true);
        gif.RunAnimation(100);
        return new PuzzleResult(gif.LightCount, "91a84e73c4b0d0185f19367fdc75f4a7");
    }
}