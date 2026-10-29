using Pzl.Everybody.Puzzles.Ece2025;

namespace Tests.Everybody.Ece2025;

public class Ece202511Tests : PuzzleTest<Ece202511>
{
    private const string InputPart1And2 = """
                                          9
                                          1
                                          1
                                          4
                                          9
                                          6
                                          """;

    [Fact]
    public void Part1() => Sut.Part1(InputPart1And2).Should().Be(109);

    [Fact]
    public void Part2_1() => Sut.Part2(InputPart1And2).Should().Be(11);

    [Fact]
    public void Part2_2()
    {
        const string input = """
                             805
                             706
                             179
                             48
                             158
                             150
                             232
                             885
                             598
                             524
                             423
                             """;

        Sut.Part2(input).Should().Be(1579);
    }
}