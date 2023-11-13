using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2017.Aoc201721;

public class Aoc201721 : AocPuzzle
{
    public override string Name => "Fractal Art";

    protected override PuzzleResult RunPart1()
    {
        var artGenerator1 = new FractalArtGenerator(InputFile);
        artGenerator1.Run(5);
        return new PuzzleResult(artGenerator1.PixelsOn, "f24d8ef1e8322a91dcdf1127a3ec636c");
    }

    protected override PuzzleResult RunPart2()
    {
        var artGenerator2 = new FractalArtGenerator(InputFile);
        artGenerator2.Run(18);
        return new PuzzleResult(artGenerator2.PixelsOn, "0e5a4e760ff761a833c010149f058fbc");
    }
}