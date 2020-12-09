using System;
using Core.ParticleSwarm;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day20 : Day2017
    {
        public Day20() : base(20)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var tracker1 = new ParticleTracker(FileInput);
            var particle = tracker1.GetClosestParticleInTheLongRunSimple();
            Console.WriteLine($"Closest particle: {particle}");

            WritePartTitle();
            var tracker2 = new ParticleTracker(FileInput);
            var remainingParticleCount = tracker2.GetRemainingParticleCount();
            Console.WriteLine($"Remaining particles: {remainingParticleCount}");
        }
    }
}