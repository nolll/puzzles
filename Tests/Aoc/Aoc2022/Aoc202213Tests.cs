using Pzl.Aoc.Puzzles.Aoc2022;

namespace Tests.Aoc.Aoc2022;

public class Aoc202213Tests
{
    [Fact]
    public void Part1()
    {
        var signal = new Aoc202213.DistressSignal();
        var result = signal.Part1(Input);

        result.Should().Be(13);
    }

    [Fact]
    public void Parse1()
    {
        var result = Aoc202213.DistressSignal.ParseSignalItem("[1,1,3,1,1]");

        result.Print().Should().Be("[1,1,3,1,1]");
    }

    [Fact]
    public void Parse2()
    {
        var result = Aoc202213.DistressSignal.ParseSignalItem("[[1],4]");

        result.Print().Should().Be("[[1],4]");
    }

    [Fact]
    public void Parse3()
    {
        var result = Aoc202213.DistressSignal.ParseSignalItem("[[[]]]");

        result.Print().Should().Be("[[[]]]");
    }

    [Fact]
    public void Parse4()
    {
        var result = Aoc202213.DistressSignal.ParseSignalItem("[[8,7,6]]");

        result.Print().Should().Be("[[8,7,6]]");
    }

    [Fact]
    public void Parse5()
    {
        var result = Aoc202213.DistressSignal.ParseSignalItem("[1,[2,[3,[4,[5,6,7]]]],8,9]");

        result.Print().Should().Be("[1,[2,[3,[4,[5,6,7]]]],8,9]");
    }

    [Fact]
    public void Compare1()
    {
        var left = Aoc202213.DistressSignal.ParseSignalItem("[1,1,3,1,1]");
        var right = Aoc202213.DistressSignal.ParseSignalItem("[1,1,5,1,1]");
        var result = Aoc202213.SignalComparer.Compare(left, right);

        result.Should().Be(-1);
    }

    [Fact]
    public void Compare2()
    {
        var left = Aoc202213.DistressSignal.ParseSignalItem("[[1],[2,3,4]]");
        var right = Aoc202213.DistressSignal.ParseSignalItem("[[1],4]");
        var result = Aoc202213.SignalComparer.Compare(left, right);

        result.Should().Be(-1);
    }

    [Fact]
    public void Compare3()
    {
        var left = Aoc202213.DistressSignal.ParseSignalItem("[9]");
        var right = Aoc202213.DistressSignal.ParseSignalItem("[[8,7,6]]");
        var result = Aoc202213.SignalComparer.Compare(left, right);

        result.Should().Be(1);
    }

    [Fact]
    public void Compare4()
    {
        var left = Aoc202213.DistressSignal.ParseSignalItem("[[4,4],4,4]");
        var right = Aoc202213.DistressSignal.ParseSignalItem("[[4,4],4,4,4]");
        var result = Aoc202213.SignalComparer.Compare(left, right);

        result.Should().Be(-1);
    }

    [Fact]
    public void Compare5()
    {
        var left = Aoc202213.DistressSignal.ParseSignalItem("[7,7,7,7]");
        var right = Aoc202213.DistressSignal.ParseSignalItem("[7,7,7]");
        var result = Aoc202213.SignalComparer.Compare(left, right);

        result.Should().Be(1);
    }

    [Fact]
    public void Compare6()
    {
        var left = Aoc202213.DistressSignal.ParseSignalItem("[]");
        var right = Aoc202213.DistressSignal.ParseSignalItem("[3]");
        var result = Aoc202213.SignalComparer.Compare(left, right);

        result.Should().Be(-1);
    }

    [Fact]
    public void Compare7()
    {
        var left = Aoc202213.DistressSignal.ParseSignalItem("[[[]]]");
        var right = Aoc202213.DistressSignal.ParseSignalItem("[[]]");
        var result = Aoc202213.SignalComparer.Compare(left, right);

        result.Should().Be(1);
    }

    [Fact]
    public void Compare8()
    {
        var left = Aoc202213.DistressSignal.ParseSignalItem("[1,[2,[3,[4,[5,6,7]]]],8,9]");
        var right = Aoc202213.DistressSignal.ParseSignalItem("[1,[2,[3,[4,[5,6,0]]]],8,9]");
        var result = Aoc202213.SignalComparer.Compare(left, right);

        result.Should().Be(1);
    }

    [Fact]
    public void Part2()
    {
        var signal = new Aoc202213.DistressSignal();
        var result = signal.Part2(Input);

        result.Should().Be(140);
    }

    private const string Input = """
                                 [1,1,3,1,1]
                                 [1,1,5,1,1]

                                 [[1],[2,3,4]]
                                 [[1],4]

                                 [9]
                                 [[8,7,6]]

                                 [[4,4],4,4]
                                 [[4,4],4,4,4]

                                 [7,7,7,7]
                                 [7,7,7]

                                 []
                                 [3]

                                 [[[]]]
                                 [[]]

                                 [1,[2,[3,[4,[5,6,7]]]],8,9]
                                 [1,[2,[3,[4,[5,6,0]]]],8,9]
                                 """;
}