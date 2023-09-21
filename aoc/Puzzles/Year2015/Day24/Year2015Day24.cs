using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day24;

public class Year2015Day24 : AocPuzzle
{
    public override string Title => "It Hangs in the Balance";

    public override PuzzleResult RunPart1()
    {
        var balancer1 = new PresentBalancer(FileInput, 3);
        return new PuzzleResult(balancer1.QuantumEntanglementOfFirstGroup, 11_266_889_531);
    }

    public override PuzzleResult RunPart2()
    {
        var balancer2 = new PresentBalancer(FileInput, 4);
        return new PuzzleResult(balancer2.QuantumEntanglementOfFirstGroup, 77_387_711);
    }
}