using System;
using System.Linq;
using Core.ImmuneSystemFight;
using Core.Tools;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day24 : Day2018
    {
        public Day24() : base(24)
        {
        }

        protected override void RunDay()
        {
            var inputs = FileInput.Split("\r\n\r\n");
            var immuneInput = inputs.First();
            var infectionInput = inputs.Last();

            WritePartTitle();
            var system = new ImmuneSystem(immuneInput, infectionInput);
            system.Fight();
            Console.WriteLine($"Winning army unit count: {system.WinningArmyUnitCount}");

            WritePartTitle();
            system.FightUntilImmuneSystemWins();
            Console.WriteLine($"Immune system unit count: {system.WinningArmyUnitCount}");
        }
    }
}