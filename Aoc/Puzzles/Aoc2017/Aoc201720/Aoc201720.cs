using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201720;

[Name("Particle Swarm")]
public class Aoc201720(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var tracker1 = new ParticleTracker(input);
        var particle = tracker1.GetClosestParticleInTheLongRunSimple();
        return new PuzzleResult(particle, "f5c83f45c41d2ac489cf09ad0e9fb299");
    }

    protected override PuzzleResult RunPart2()
    {
        var tracker2 = new ParticleTracker(input);
        var remainingParticleCount = tracker2.GetRemainingParticleCount();
        return new PuzzleResult(remainingParticleCount, "ad8cf8aeb67231056821e6658af28967");
    }
}