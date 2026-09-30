using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201524Tests : PuzzleTest<Aoc201524>
{
    [Fact]
    public void QuantumEntanglementOfFirstGroupIsCorrect()
    {
        const string input = """
                             1
                             2
                             3
                             4
                             5
                             7
                             8
                             9
                             10
                             11
                             """;

        var balancer = new Aoc201524.PresentBalancer(input.Trim(), 3);

        balancer.QuantumEntanglementOfFirstGroup.Should().Be(99);
    }
}