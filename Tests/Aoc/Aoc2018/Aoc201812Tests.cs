using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201812Tests : PuzzleTest<Aoc201812>
{
    private const string Input = """
                                 initial state: #..#.#..##......###...###

                                 ...## => #
                                 ..#.. => #
                                 .#... => #
                                 .#.#. => #
                                 .#.## => #
                                 .##.. => #
                                 .#### => #
                                 #.#.# => #
                                 #.### => #
                                 ##.#. => #
                                 ##.## => #
                                 ###.. => #
                                 ###.# => #
                                 ####. => #
                                 """;

    [Fact]
    public void PlantScoreIsCorrect() => Sut.Part1(Input).Should().Be(325);
}