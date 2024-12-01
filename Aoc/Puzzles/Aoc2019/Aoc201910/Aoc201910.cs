using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201910;

[Name("Monitoring Station")]
public class Aoc201910 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var detector = new AsteroidDetector();
        var detectorResult = detector.Detect(input);

        return new PuzzleResult(detectorResult.RayCount, "1ce0626fd555d7e4aa7dfebfe816d1ed");
    }

    public PuzzleResult RunPart2(string input)
    {
        var vaporizer = new AsteroidVaporizer();
        var vaporizeResult = vaporizer.Vaporize(input);
        var asteroidNr200 = vaporizeResult.DestroyedAsteroids[199];
        var result = asteroidNr200.X * 100 + asteroidNr200.Y;

        return new PuzzleResult(result, "5351b6b34f35abf16b9c55c691804327");
    }
}