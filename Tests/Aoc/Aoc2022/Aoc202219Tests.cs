using Pzl.Aoc.Puzzles.Aoc2022;

namespace Tests.Aoc.Aoc2022;

public class Aoc202219Tests : PuzzleTest<Aoc202219>
{
    [Fact]
    public void Part1_First() => Aoc202219.FindBestConfiguration(Aoc202219.ParseBlueprint(
        "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian."
    ), 24).GeodeCount.Should().Be(9);

    [Fact]
    public void Part1_Second() => Aoc202219.FindBestConfiguration(Aoc202219.ParseBlueprint(
        "Blueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian."
    ), 24).GeodeCount.Should().Be(12);

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(33);

    [Fact]
    public void Part2_First() => Aoc202219.FindBestConfiguration(Aoc202219.ParseBlueprint(
        "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian."
    ), 32).GeodeCount.Should().Be(56);

    [Fact]
    public void Part2_Second() => Aoc202219.FindBestConfiguration(Aoc202219.ParseBlueprint(
        "Blueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian."
    ), 32).GeodeCount.Should().Be(62);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(3472);

    private const string Input = """
                                 Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.
                                 Blueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.
                                 """;
}