using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody16;

public class Everybody16Tests
{
    private const string Input = """
                                 1,2,3

                                 ^_^ -.- ^,-
                                 >.- ^_^ >.<
                                 -_- -.- >.<
                                     -.^ ^_^
                                     >.>
                                 """;

    [Test]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be(">.- -.- ^,-");

    [TestCase(1, 1)]
    [TestCase(2, 2)]
    [TestCase(3, 4)]
    [TestCase(4, 5)]
    [TestCase(5, 7)]
    [TestCase(10, 15)]
    [TestCase(100, 138)]
    [TestCase(1000, 1383)]
    [TestCase(10000, 13833)]
    [TestCase(100000, 138333)]
    [TestCase(1000000, 1383333)]
    [TestCase(10000000, 13833333)]
    [TestCase(100000000, 138333333)]
    [TestCase(1000000000, 1383333333)]
    [TestCase(10000000000, 13833333333)]
    [TestCase(100000000000, 138333333333)]
    [TestCase(202420242024, 280014668134)]
    public void Part2(long target, long expected) => Sut.Part2(Input, target).Should().Be(expected);
    
    [TestCase(1, 4, 1)]
    [TestCase(2, 6, 1)]
    [TestCase(3, 9, 2)]
    [TestCase(10, 26, 5)]
    [TestCase(100, 246, 50)]
    [TestCase(256, 627, 128)]
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
    
    [Test]
    public void PrevNext1()
    {
        var result = Sut.GetNextPositions(_counts, _increments, [0, 0, 0]);

        result[0].Should().BeEquivalentTo([0, 1, 2]);
        result[1].Should().BeEquivalentTo([1, 2, 3]);
        result[2].Should().BeEquivalentTo([2, 3, 0]);
    }
    
    [Test]
    public void PrevNext2()
    {
        var result = Sut.GetNextPositions(_counts, _increments, [0, 1, 2]);

        result[0].Should().BeEquivalentTo([0, 2, 0]);
        result[1].Should().BeEquivalentTo([1, 3, 1]);
        result[2].Should().BeEquivalentTo([2, 4, 2]);
    }
    
    [Test]
    public void PrevNext3()
    {
        var result = Sut.GetNextPositions(_counts, _increments, [1, 2, 3]);

        result[0].Should().BeEquivalentTo([1, 3, 1]);
        result[1].Should().BeEquivalentTo([2, 4, 2]);
        result[2].Should().BeEquivalentTo([0, 0, 3]);
    }
    
    [Test]
    public void PrevNext4()
    {
        var result = Sut.GetNextPositions(_counts, _increments, [2, 3, 0]);

        result[0].Should().BeEquivalentTo([2, 4, 2]);
        result[1].Should().BeEquivalentTo([0, 0, 3]);
        result[2].Should().BeEquivalentTo([1, 1, 0]);
    }

    [TestCase(">.--.-^_^", 1)]
    [TestCase("-_->.>>.<", 1)]
    [TestCase("^_^^_^>.<", 2)]
    [TestCase("^_^^_^^_^", 5)]
    public void Scoring(string input, int expected) => Everybody16.Score(input).Should().Be(expected);

    private static Everybody16 Sut => new();
}