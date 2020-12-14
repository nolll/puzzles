using Core.Bitmasking;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day14 : Day2020
    {
        public Day14() : base(14)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var system = new BitmaskSystem1();
            var sum = system.Run(FileInput);
            return new PuzzleResult(sum, 11_179_633_149_677);
        }

        public override PuzzleResult RunPart2()
        {
            var system = new BitmaskSystem2();
            var sum = system.Run(FileInput);
            return new PuzzleResult(sum, 4_822_600_194_774);
        }
    }
}