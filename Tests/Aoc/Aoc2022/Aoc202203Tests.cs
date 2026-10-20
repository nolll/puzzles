using Pzl.Aoc.Puzzles.Aoc2022;

namespace Tests.Aoc.Aoc2022;

public class Aoc202203Tests : PuzzleTest<Aoc202203>
{
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(157);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(70);

    private const string Input = """
                                 vJrwpWtwJgWrhcsFMMfFFhFp
                                 jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
                                 PmmdzqPrVvPwwTWBwg
                                 wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
                                 ttgJtRGJQctTZtZT
                                 CrZsJsPPZsGzwwsLwLmpwMDw
                                 """;
}