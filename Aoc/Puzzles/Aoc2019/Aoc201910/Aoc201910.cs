using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201910;

[Name("Monitoring Station")]
public class Aoc201910 : AocPuzzle
{
    [Puzzle("1ce0626fd555d7e4aa7dfebfe816d1ed")]
    public int Part1(string input) => new AsteroidDetector().Detect(input).RayCount;

    [Puzzle("5351b6b34f35abf16b9c55c691804327")]
    public int Part2(string input)
    {
        var vaporizer = new AsteroidVaporizer();
        var vaporizeResult = vaporizer.Vaporize(input);
        var asteroid = vaporizeResult.DestroyedAsteroids[199];
        return asteroid.X * 100 + asteroid.Y;
    }
}