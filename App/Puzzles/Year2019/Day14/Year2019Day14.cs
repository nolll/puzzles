using App.Platform;

namespace App.Puzzles.Year2019.Day14
{
    public class Year2019Day14 : Year2019Day
    {
        public override int Day => 14;

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