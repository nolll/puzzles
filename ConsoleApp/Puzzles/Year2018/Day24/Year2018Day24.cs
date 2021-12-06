using System.Linq;

namespace ConsoleApp.Puzzles.Year2018.Day24
{
    public class Year2018Day24 : Year2018Day
    {
        public override int Day => 24;

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