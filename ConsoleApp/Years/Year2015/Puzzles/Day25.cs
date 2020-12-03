using System;
using Core.WeatherMachine;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day25 : Day2015
    {
        public Day25() : base(25)
        {
        }

        protected override void RunDay()
        {
            var p = GetParams();

            WritePartTitle();
            var codeFinder = new WeatherMachineCodeFinder();
            var code = codeFinder.FindCodeAt(p.TargetX, p.TargetY);
            Console.WriteLine($"Weather Machine code: {code}");
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