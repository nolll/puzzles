using Pzl.Aoc.Puzzles.Aoc2023;

namespace Tests.Aoc.Aoc2023;

public class Aoc202320Tests : PuzzleTest<Aoc202320>
{
    [Fact]
    public void CountPulsesExample1()
    {
        const string input = """
                             broadcaster -> a, b, c
                             %a -> b
                             %b -> c
                             %c -> inv
                             &inv -> a
                             """;

        Sut.CountPulses(input, 1000).Should().Be(32000000);
    }
    
    [Fact]
    public void CountPulsesExample2()
    {
        const string input = """
                             broadcaster -> a
                             %a -> inv, con
                             &inv -> b
                             %b -> con
                             &con -> output
                             """;

        Sut.CountPulses(input, 1000).Should().Be(11687500);
    }
}