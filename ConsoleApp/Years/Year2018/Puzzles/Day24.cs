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

        public override PuzzleResult RunPart1()
        {
            var inputs = FileInput.Split("\r\n\r\n");
            var immuneInput = inputs.First();
            var infectionInput = inputs.Last();

            var system = new ImmuneSystem(immuneInput, infectionInput);
            system.Fight();
            return new PuzzleResult(system.WinningArmyUnitCount, 9328);
        }

        public override PuzzleResult RunPart2()
        {
            var inputs = FileInput.Split("\r\n\r\n");
            var immuneInput = inputs.First();
            var infectionInput = inputs.Last();
            
            var system = new ImmuneSystem(immuneInput, infectionInput);
            system.FightUntilImmuneSystemWins();
            return new PuzzleResult(system.WinningArmyUnitCount, 2172);
        }
    }
}