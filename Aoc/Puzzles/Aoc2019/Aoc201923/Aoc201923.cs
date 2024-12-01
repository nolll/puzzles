using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201923;

[Name("Category Six")]
public class Aoc201923 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var network = new CategorySixNetwork(input);
        network.Run();

        return new PuzzleResult(network.FirstNatPacket!.Y, "d95714c17b4e575c231127539580c9ac");
    }

    public PuzzleResult RunPart2(string input)
    {
        var network = new CategorySixNetwork(input);
        network.Run();

        return new PuzzleResult(network.FirstRepeatedNatPacket!.Y, "d30f34de7c79a751083a20b903069390");
    }
}