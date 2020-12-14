using System;
using Core.MakeFuel;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day14 : Day2019
    {
        public Day14() : base(14)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var reactor = new NanoReactor(FileInput);
            reactor.Run();
            var oreForOneFuel = reactor.RequiredOreForOneFuel;

            return new PuzzleResult(oreForOneFuel, 469_536);
        }

        public override PuzzleResult RunPart2()
        {
            var reactor = new NanoReactor(FileInput);
            reactor.Run();
            var fuelCount = reactor.FuelFromOneTrillionOre;

            return new PuzzleResult(fuelCount, 3_343_477);
        }
    }
}