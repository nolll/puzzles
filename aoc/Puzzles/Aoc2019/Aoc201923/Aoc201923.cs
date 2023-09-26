using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2019.Aoc201923;

public class Aoc201923 : AocPuzzle
{
    public override string Name => "Category Six";

    protected override PuzzleResult RunPart1()
    {
        var network = new CategorySixNetwork(InputFile);
        network.Run();

        return new PuzzleResult(network.FirstNatPacket!.Y, 17_541);
    }

    protected override PuzzleResult RunPart2()
    {
        var network = new CategorySixNetwork(InputFile);
        network.Run();

        return new PuzzleResult(network.FirstRepeatedNatPacket!.Y, 12_415);
    }
}