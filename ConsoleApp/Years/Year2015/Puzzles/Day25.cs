using System;
using Core.WeatherMachine;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day25 : Day2015
    {
        public Day25() : base(25)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var p = GetParams();
            var codeFinder = new WeatherMachineCodeFinder();
            var code = codeFinder.FindCodeAt(p.TargetX, p.TargetY);
            return new PuzzleResult($"Weather Machine code: {code}");
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
                TargetX = int.Parse(words[16]),
                TargetY = int.Parse(words[18])
            };
        }

        private class Params
        {
            public int TargetX { get; set; }
            public int TargetY { get; set; }
        }
    }
}