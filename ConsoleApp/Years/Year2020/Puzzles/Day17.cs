using Core.ExperimentalEnergySource;
using Core.TicketValidation;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day17 : Day2020
    {
        public Day17() : base(17)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var cube = new ConwayCube();
            var result = cube.Boot(FileInput, 6);
            return new PuzzleResult(result);
        }

    }
}