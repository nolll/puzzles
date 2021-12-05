using Core.ParticleSwarm;

namespace ConsoleApp.Puzzles.Year2017.Puzzles
{
    public class Year2017Day20 : Year2017Day
    {
        public override int Day => 20;

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
}