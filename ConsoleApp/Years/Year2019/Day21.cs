using System;
using Core.SpringDroidAdventure;

namespace ConsoleApp.Years.Year2019
{
    public class Day21 : Day
    {
        public Day21() : base(21)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var walkingDroid = new SpringDroid(WalkProgram);
            walkingDroid.Run();
            Console.WriteLine($"Hull damage: {walkingDroid.HullDamage}");

            WritePartTitle();
            var runningDroid = new SpringDroid(RunProgram);
            runningDroid.Run();
            Console.WriteLine($"Hull damage: {runningDroid.HullDamage}");
        }

        private const string WalkProgram = @"
NOT A J
NOT B T
OR T J
NOT C T
OR T J
AND D J
WALK";

        private const string RunProgram = @"
NOT A J
NOT B T
OR T J
NOT C T
OR T J
AND D J
RUN";
    }
}