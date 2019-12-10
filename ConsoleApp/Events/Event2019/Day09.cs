using System;
using ConsoleApp.Inputs;
using Core.Asteroids;
using Core.Computer;

namespace ConsoleApp.Events.Event2019
{
    public class Day09 : Day
    {
        public Day09() : base(9)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var boostTester = new BoostRunner(InputData.ComputerProgramDay9, 1);
            var testerResult = boostTester.Run();

            Console.WriteLine($"BOOST keycode: {testerResult.LastOutput}");

            WritePartTitle();
            var boostRunner = new BoostRunner(InputData.ComputerProgramDay9, 2);
            var runnerResult = boostRunner.Run();

            Console.WriteLine($"Coordinates: {runnerResult.LastOutput}");
        }
    }

    public class Day10 : Day
    {
        public Day10() : base(10)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var detector = new AsteroidDetector();
            var result = detector.Detect(InputData.Asteroids);

            Console.WriteLine($"Asteroid count: {result.RayCount}");
        }
    }
}