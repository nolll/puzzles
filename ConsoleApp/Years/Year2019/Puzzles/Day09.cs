using System;
using Core.Computer;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day09 : Day2019
    {
        public Day09() : base(9)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var boostTester = new BoostRunner(FileInput, 1);
            var testerResult = boostTester.Run();

            Console.WriteLine($"BOOST keycode: {testerResult.LastOutput}");

            WritePartTitle();
            var boostRunner = new BoostRunner(FileInput, 2);
            var runnerResult = boostRunner.Run();

            Console.WriteLine($"Coordinates: {runnerResult.LastOutput}");
        }
    }
}