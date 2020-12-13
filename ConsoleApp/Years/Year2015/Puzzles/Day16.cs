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
            return new PuzzleResult(sueSelector.SueNumberPart1, 373);
        }

        public override PuzzleResult RunPart2()
        {
            var sueSelector = new SueSelector(FileInput);
            return new PuzzleResult(sueSelector.SueNumberPart2, 260);
        }
    }
}