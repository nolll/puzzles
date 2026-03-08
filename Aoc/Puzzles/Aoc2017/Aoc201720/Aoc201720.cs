using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201720;

[Name("Particle Swarm")]
public class Aoc201720 : AocPuzzle
{
    [Puzzle("f5c83f45c41d2ac489cf09ad0e9fb299")]
    public int Part1(string input) => new ParticleTracker(input).GetClosestParticleInTheLongRunSimple();

    [Puzzle("ad8cf8aeb67231056821e6658af28967")]
    public int Part2(string input)
    {
        var tracker = new ParticleTracker(input);
        return tracker.GetRemainingParticleCount();
    }
}