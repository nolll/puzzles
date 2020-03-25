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

        /*
sätt J true om A är hål
sätt T true om B är hål
sätt J true om A eller B är hål
sätt T true om C är hål
sätt J true om A, B eller C är hål
sätt J true om D OCH (A, B eller C) är hål
         */

        private const string RunProgram = @"
NOT A J
NOT B T
OR T J
NOT C T
OR T J

AND D J

AND E J
OR H J
RUN";
    }
}