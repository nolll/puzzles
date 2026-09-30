using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201603Tests : PuzzleTest<Aoc201603>
{
    [Theory]
    [InlineData("12 13 14", true)]
    [InlineData("1 2 5", false)]
    public void ValidateTriangles(string triangleSpec, bool expectedResult) => 
        Sut.IsValid(triangleSpec).Should().Be(expectedResult);

    [Fact]
    public void ValidHorizontalCount()
    {
        const string input = """
                             12 13 14
                             1 2 5
                             """;
        
        Sut.GetHorizontalValidCount(input).Should().Be(1);
    }

    [Fact]
    public void ValidVerticalCount()
    {
        const string input = """
                             101 301 501
                             102 302 502
                             103 303 503
                             201 401 601
                             202 402 602
                             203 403 603
                             """;
        
        Sut.GetVerticalValidCount(input).Should().Be(6);
    }
}