using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201715Tests : PuzzleTest<Aoc201715>
{
    [Fact]
    public void Part1_MatchCountIsOneAfter5Runs()
    {
        var duel = new Aoc201715.GeneratorDuel(65, 8921);
        duel.Run(5);

        duel.FinalCount.Should().Be(1);
    }

    [Fact]
    public void Part1_MatchCountIsOneAfter40MRuns()
    {
        var duel = new Aoc201715.GeneratorDuel(65, 8921);
        duel.Run(40_000_000);

        duel.FinalCount.Should().Be(588);
    }

    [Fact]
    public void Part2_Finds309PairsIn5Runs()
    {
        var duel = new Aoc201715.GeneratorDuel(65, 8921);
        duel.Run2(5_000_000);

        duel.FinalCount.Should().Be(309);
    }
}