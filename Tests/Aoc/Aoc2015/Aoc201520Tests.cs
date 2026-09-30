using Pzl.Aoc.Puzzles.Aoc2015;
using Pzl.Tools.Maths;

namespace Tests.Aoc.Aoc2015;

public class Aoc201520Tests : PuzzleTest<Aoc201520>
{
    [Fact]
    public void FirstHouseToGet150Presents() => Sut.Deliver1(150, false).Should().Be(8);

    [Fact]
    public void FindIntFactors8()
    {
        var result = Sut.FindIntFactors(8).OrderBy(o => o).ToList();

        result.Count.Should().Be(4);
        result[0].Should().Be(1);
        result[1].Should().Be(2);
        result[2].Should().Be(4);
        result[3].Should().Be(8);
    }

    [Fact]
    public void FindIntFactors81()
    {
        var result = Sut.FindIntFactors(81).OrderBy(o => o).ToList();

        result.Count.Should().Be(5);
        result[0].Should().Be(1);
        result[1].Should().Be(3);
        result[2].Should().Be(9);
        result[3].Should().Be(27);
        result[4].Should().Be(81);
    }

    [Fact]
    public void FindIntFactors2354()
    {
        var result = Sut.FindIntFactors(2354).OrderBy(o => o).ToList();

        result.Count.Should().Be(8);
        result[0].Should().Be(1);
        result[1].Should().Be(2);
        result[2].Should().Be(11);
        result[3].Should().Be(22);
        result[4].Should().Be(107);
        result[5].Should().Be(214);
        result[6].Should().Be(1177);
        result[7].Should().Be(2354);
    }

    [Fact]
    public void IntFactorFuncIsCorrect()
    {
        var myResult = Sut.FindIntFactors(786_240).OrderBy(o => o).ToList();
        var internetResult = MathTools.GetFactors(786_240);
        myResult.Count.Should().Be(internetResult.Count);
    }
}