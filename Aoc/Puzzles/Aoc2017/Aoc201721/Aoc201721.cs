using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201721;

[Name("Fractal Art")]
public class Aoc201721 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var artGenerator1 = new FractalArtGenerator(input);
        artGenerator1.Run(5);
        return new PuzzleResult(artGenerator1.PixelsOn, "f24d8ef1e8322a91dcdf1127a3ec636c");
    }

    public PuzzleResult RunPart2(string input)
    {
        var artGenerator2 = new FractalArtGenerator(input);
        artGenerator2.Run(18);
        return new PuzzleResult(artGenerator2.PixelsOn, "0e5a4e760ff761a833c010149f058fbc");
    }
}