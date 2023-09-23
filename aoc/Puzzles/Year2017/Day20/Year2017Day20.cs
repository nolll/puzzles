using Common.Puzzles;

namespace Aoc.Puzzles.Year2017.Day20;

public class Year2017Day20 : AocPuzzle
{
    public override string Name => "Particle Swarm";

    protected override PuzzleResult RunPart1()
    {
        var tracker1 = new ParticleTracker(FileInput);
        var particle = tracker1.GetClosestParticleInTheLongRunSimple();
        return new PuzzleResult(particle, 150);
    }

    protected override PuzzleResult RunPart2()
    {
        var tracker2 = new ParticleTracker(FileInput);
        var remainingParticleCount = tracker2.GetRemainingParticleCount();
        return new PuzzleResult(remainingParticleCount, 657);
    }
}