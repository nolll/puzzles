using Core.Platform;

namespace Core.Puzzles.Year2015.Day25
{
    public class Year2015Day25 : Year2015Day
    {
        public override int Day => 25;

        public override PuzzleResult RunPart1()
        {
            var p = GetParams();
            var codeFinder = new WeatherMachineCodeFinder();
            var code = codeFinder.FindCodeAt(p.TargetX, p.TargetY);
            return new PuzzleResult(code, 2_650_453);
        }

        public override PuzzleResult RunPart2()
        {
            return new EmptyPuzzleResult();
        }

        private Params GetParams()
        {
            var words = FileInput.Replace(".", "").Replace(",", "").Split(' ');

            return new Params
            {
                TargetX = int.Parse(words[18]),
                TargetY = int.Parse(words[16])
            };
        }

        private class Params
        {
            public int TargetX { get; set; }
            public int TargetY { get; set; }
        }
    }
}