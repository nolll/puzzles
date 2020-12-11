using Core.AuntSue;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day16 : Day2015
    {
        public Day16() : base(16)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var sueSelector = new SueSelector(FileInput);
            return new PuzzleResult($"Sue number, part 1: {sueSelector.SueNumberPart1}");
        }

        public override PuzzleResult RunPart2()
        {
            var sueSelector = new SueSelector(FileInput);
            return new PuzzleResult($"Sue number, part 2: {sueSelector.SueNumberPart2}");
        }
    }
}