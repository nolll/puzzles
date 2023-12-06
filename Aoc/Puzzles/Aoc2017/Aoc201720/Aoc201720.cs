using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201720;

public class Aoc201720 : AocPuzzle
{
    public override string Name => "Particle Swarm";

    protected override PuzzleResult RunPart1()
    {
        var tracker1 = new ParticleTracker(InputFile);
        var particle = tracker1.GetClosestParticleInTheLongRunSimple();
        return new PuzzleResult(particle, "f5c83f45c41d2ac489cf09ad0e9fb299");
    }

    protected override PuzzleResult RunPart2()
    {
        var tracker2 = new ParticleTracker(InputFile);
        var remainingParticleCount = tracker2.GetRemainingParticleCount();
        return new PuzzleResult(remainingParticleCount, "ad8cf8aeb67231056821e6658af28967");
    }
}