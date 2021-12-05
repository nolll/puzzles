using Core.AuntSue;

namespace ConsoleApp.Puzzles.Year2015.Puzzles
{
    public class Year2015Day16 : Year2015Day
    {
        public override int Day => 16;

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