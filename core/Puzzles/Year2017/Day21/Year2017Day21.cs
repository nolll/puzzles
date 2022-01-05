using Core.Platform;

namespace Core.Puzzles.Year2017.Day21;

public class Year2017Day21 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var artGenerator1 = new FractalArtGenerator(FileInput);
        artGenerator1.Run(5);
        return new PuzzleResult(artGenerator1.PixelsOn, 123);
    }

    public override PuzzleResult RunPart2()
    {
        var artGenerator2 = new FractalArtGenerator(FileInput);
        artGenerator2.Run(18);
        return new PuzzleResult(artGenerator2.PixelsOn, 1984683);
    }
}