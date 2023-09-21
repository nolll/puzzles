using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day10;

public class Year2019Day10 : AocPuzzle
{
    public override string Title => "Monitoring Station";

    public override PuzzleResult RunPart1()
    {
        var detector = new AsteroidDetector();
        var detectorResult = detector.Detect(FileInput);

        return new PuzzleResult(detectorResult.RayCount, 340);
    }

    public override PuzzleResult RunPart2()
    {
        var vaporizer = new AsteroidVaporizer();
        var vaporizeResult = vaporizer.Vaporize(FileInput);
        var asteroidNr200 = vaporizeResult.DestroyedAsteroids[199];
        var result = asteroidNr200.X * 100 + asteroidNr200.Y;

        return new PuzzleResult(result, 2628);
    }
}