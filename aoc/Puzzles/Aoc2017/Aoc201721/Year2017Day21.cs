using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2017.Aoc201721;

public class Year2017Day21 : AocPuzzle
{
    public override string Name => "Fractal Art";

    protected override PuzzleResult RunPart1()
    {
        var artGenerator1 = new FractalArtGenerator(InputFile);
        artGenerator1.Run(5);
        return new PuzzleResult(artGenerator1.PixelsOn, 123);
    }

    protected override PuzzleResult RunPart2()
    {
        var artGenerator2 = new FractalArtGenerator(InputFile);
        artGenerator2.Run(18);
        return new PuzzleResult(artGenerator2.PixelsOn, 1984683);
    }
}