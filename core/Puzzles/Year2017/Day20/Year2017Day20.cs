using Core.Platform;

namespace Core.Puzzles.Year2017.Day20;

public class Year2017Day20 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var tracker1 = new ParticleTracker(FileInput);
        var particle = tracker1.GetClosestParticleInTheLongRunSimple();
        return new PuzzleResult(particle, 150);
    }

    public override PuzzleResult RunPart2()
    {
        var tracker2 = new ParticleTracker(FileInput);
        var remainingParticleCount = tracker2.GetRemainingParticleCount();
        return new PuzzleResult(remainingParticleCount, 657);
    }
}