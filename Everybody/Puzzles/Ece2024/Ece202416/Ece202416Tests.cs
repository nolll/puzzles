namespace Pzl.Everybody.Puzzles.Ece2024.Ece202416;

public class Ece202416Tests
{
    private const string Input = """
                                 1,2,3

                                 ^_^ -.- ^,-
                                 >.- ^_^ >.<
                                 -_- -.- >.<
                                     -.^ ^_^
                                     >.>
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be(">.- -.- ^,-");

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 4)]
    [InlineData(4, 5)]
    [InlineData(5, 7)]
    [InlineData(10, 15)]
    [InlineData(100, 138)]
    [InlineData(1000, 1383)]
    [InlineData(10000, 13833)]
    [InlineData(100000, 138333)]
    [InlineData(1000000, 1383333)]
    [InlineData(10000000, 13833333)]
    [InlineData(100000000, 138333333)]
    [InlineData(1000000000, 1383333333)]
    [InlineData(10000000000, 13833333333)]
    [InlineData(100000000000, 138333333333)]
    [InlineData(202420242024, 280014668134)]
    public void Part2(long target, long expected) => Sut.Part2(Input, target).Should().Be(expected);
    
    [Theory]
    [InlineData(1, 4, 1)]
    [InlineData(2, 6, 1)]
    [InlineData(3, 9, 2)]
    [InlineData(10, 26, 5)]
    [InlineData(100, 246, 50)]
    [InlineData(256, 627, 128)]
    public void Part3(int pulls, int max, int min)
    {
        const string input = """
                             1,2,3

                             ^_^ -.- ^,-
                             >.- ^_^ >.<
                             -_- -.- ^.^
                                 -.^ >.<
                                 >.>
                             """;

        var (rmin, rmax) = Sut.Part3(input, pulls);
        rmax.Should().Be(max);
        rmin.Should().Be(min);
    }

    private readonly int[] _counts = [3, 5, 4];
    private readonly int[] _increments = [1, 2, 3];
    
    [Fact]
    public void PrevNext1()
    {
        var result = Sut.GetNextPositions(_counts, _increments, [0, 0, 0]);

        result[0].Should().BeEquivalentTo([0, 1, 2]);
        result[1].Should().BeEquivalentTo([1, 2, 3]);
        result[2].Should().BeEquivalentTo([2, 3, 0]);
    }
    
    [Fact]
    public void PrevNext2()
    {
        var result = Sut.GetNextPositions(_counts, _increments, [0, 1, 2]);

        result[0].Should().BeEquivalentTo([0, 2, 0]);
        result[1].Should().BeEquivalentTo([1, 3, 1]);
        result[2].Should().BeEquivalentTo([2, 4, 2]);
    }
    
    [Fact]
    public void PrevNext3()
    {
        var result = Sut.GetNextPositions(_counts, _increments, [1, 2, 3]);

        result[0].Should().BeEquivalentTo([1, 3, 1]);
        result[1].Should().BeEquivalentTo([2, 4, 2]);
        result[2].Should().BeEquivalentTo([0, 0, 3]);
    }
    
    [Fact]
    public void PrevNext4()
    {
        var result = Sut.GetNextPositions(_counts, _increments, [2, 3, 0]);

        result[0].Should().BeEquivalentTo([2, 4, 2]);
        result[1].Should().BeEquivalentTo([0, 0, 3]);
        result[2].Should().BeEquivalentTo([1, 1, 0]);
    }

    [Theory]
    [InlineData(">.--.-^_^", 1)]
    [InlineData("-_->.>>.<", 1)]
    [InlineData("^_^^_^>.<", 2)]
    [InlineData("^_^^_^^_^", 5)]
    public void Scoring(string input, int expected) => Ece202416.Score(input).Should().Be(expected);

    private static Ece202416 Sut => new();
}