using System;
using Core.SpringDroidAdventure;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day21 : Day2019
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
OR A T
AND B T
AND C T
NOT T J
AND D J
WALK";

        private const string RunProgram = @"
OR A T
AND B T
AND C T
NOT T J
OR E T
OR H T
AND T J
AND D J
RUN";
    }
}