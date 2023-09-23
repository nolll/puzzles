using Common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day10;

public class Year2019Day10 : AocPuzzle
{
    public override string Name => "Monitoring Station";

    protected override PuzzleResult RunPart1()
    {
        var detector = new AsteroidDetector();
        var detectorResult = detector.Detect(InputFile);

        return new PuzzleResult(detectorResult.RayCount, 340);
    }

    protected override PuzzleResult RunPart2()
    {
        var vaporizer = new AsteroidVaporizer();
        var vaporizeResult = vaporizer.Vaporize(InputFile);
        var asteroidNr200 = vaporizeResult.DestroyedAsteroids[199];
        var result = asteroidNr200.X * 100 + asteroidNr200.Y;

        return new PuzzleResult(result, 2628);
    }
}