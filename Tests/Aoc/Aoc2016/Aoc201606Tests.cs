using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201606Tests : PuzzleTest<Aoc201606>
{
    private const string Input = """
                                 eedadn
                                 drvtee
                                 eandsr
                                 raavrd
                                 atevrs
                                 tsrnev
                                 sdttsa
                                 rasrtv
                                 nssdts
                                 ntnada
                                 svetve
                                 tesnvt
                                 vntsnd
                                 vrdear
                                 dvrsen
                                 enarar
                                 """;

    [Fact]
    public void MessageIsCorrect_MostCommon() => Sut.Part1(Input).Should().Be("easter");

    [Fact]
    public void MessageIsCorrect_LeastCommon() => Sut.Part2(Input).Should().Be("advent");
}