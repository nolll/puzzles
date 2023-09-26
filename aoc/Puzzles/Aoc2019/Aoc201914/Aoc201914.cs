using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2019.Aoc201914;

public class Aoc201914 : AocPuzzle
{
    public override string Name => "Space Stoichiometry";

    protected override PuzzleResult RunPart1()
    {
        var reactor = new NanoReactor(InputFile);
        reactor.Run();
        var oreForOneFuel = reactor.RequiredOreForOneFuel;

        return new PuzzleResult(oreForOneFuel, 469_536);
    }

    protected override PuzzleResult RunPart2()
    {
        var reactor = new NanoReactor(InputFile);
        reactor.Run();
        var fuelCount = reactor.FuelFromOneTrillionOre;

        return new PuzzleResult(fuelCount, 3_343_477);
    }
}