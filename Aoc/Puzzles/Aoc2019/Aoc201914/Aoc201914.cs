using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201914;

[Name("Space Stoichiometry")]
public class Aoc201914 : AocPuzzle
{
    [Puzzle("4f7b51a9155bea7c24bbb1d4757e4bf1")]
    public long Part1(string input)
    {
        var reactor = new NanoReactor(input);
        reactor.Run();
        return reactor.RequiredOreForOneFuel;
    }

    [Puzzle("d2bf7b83647cf534681bd96e1a53db40")]
    public long Part2(string input)
    {
        var reactor = new NanoReactor(input);
        reactor.Run();
        return reactor.FuelFromOneTrillionOre;
    }
}