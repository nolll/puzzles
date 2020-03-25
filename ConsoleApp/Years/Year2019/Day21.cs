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
            var droid = new SpringDroid(Input);
            droid.Run();
            Console.WriteLine($"Hull damage: {droid.HullDamage}");
        }

        private const string Input = @"
NOT A J
NOT B T
OR T J
NOT C T
OR T J
AND D J
WALK";
    }
}