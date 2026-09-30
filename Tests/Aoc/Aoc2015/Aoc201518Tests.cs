using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201518Tests : PuzzleTest<Aoc201518>
{
    private const string Input = """
                                 .#.#.#
                                 ...##.
                                 #....#
                                 ..#...
                                 #.#..#
                                 ####..
                                 """;

    [Theory]
    [InlineData(1, false, 11)]
    [InlineData(2, false, 8)]
    [InlineData(3, false, 4)]
    [InlineData(4, false, 4)]
    [InlineData(1, true, 18)]
    [InlineData(2, true, 18)]
    [InlineData(3, true, 18)]
    [InlineData(4, true, 14)]
    [InlineData(5, true, 17)]
    public void LightCountAfterOneStep(int steps, bool litCorners, int expected) =>
        Sut.RunAnimation(Input, steps, litCorners).Should().Be(expected);
}