using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201507Tests
{
    [Fact]
    public void SignalsAreCorrect()
    {
        const string input = """
                             123 -> x
                             456 -> y
                             x AND y -> d
                             x OR y -> e
                             x LSHIFT 2 -> f
                             y RSHIFT 2 -> g
                             NOT x -> h
                             NOT y -> i
                             """;
        
        var wires = Sut.RunOne(input);

        wires["d"].Signal.Should().Be(72);
        wires["e"].Signal.Should().Be(507);
        wires["f"].Signal.Should().Be(492);
        wires["g"].Signal.Should().Be(114);
        wires["h"].Signal.Should().Be(65412);
        wires["i"].Signal.Should().Be(65079);
        wires["x"].Signal.Should().Be(123);
        wires["y"].Signal.Should().Be(456);
    }

    private static Aoc201507 Sut => new();
}