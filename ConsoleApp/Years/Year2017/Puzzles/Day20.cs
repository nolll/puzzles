using System;
using Core.ParticleSwarm;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day20 : Day2017
    {
        public Day20() : base(20)
        {
        }

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