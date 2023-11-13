using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2019.Aoc201923;

public class Aoc201923 : AocPuzzle
{
    public override string Name => "Category Six";

    protected override PuzzleResult RunPart1()
    {
        var network = new CategorySixNetwork(InputFile);
        network.Run();

        return new PuzzleResult(network.FirstNatPacket!.Y, "d95714c17b4e575c231127539580c9ac");
    }

    protected override PuzzleResult RunPart2()
    {
        var network = new CategorySixNetwork(InputFile);
        network.Run();

        return new PuzzleResult(network.FirstRepeatedNatPacket!.Y, "d30f34de7c79a751083a20b903069390");
    }
}