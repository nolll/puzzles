namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201606;

public class Aoc201606Tests
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
    public void MessageIsCorrect_MostCommon()
    {
        var reader = new RepetitionCodeReader();
        var coin = reader.ReadMostCommon(Input);

        coin.Should().Be("easter");
    }

    [Fact]
    public void MessageIsCorrect_LeastCommon()
    {
        var reader = new RepetitionCodeReader();
        var coin = reader.ReadLeastCommon(Input);

        coin.Should().Be("advent");
    }
}