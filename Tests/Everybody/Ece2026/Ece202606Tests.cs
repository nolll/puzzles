using Pzl.Everybody.Puzzles.Ece2026;

namespace Tests.Everybody.Ece2026;

public class Ece202606Tests : PuzzleTest<Ece202606>
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             BRDS:FLWR,SLTT,YSTS
                             FLWR:SLTT,YSTS
                             SLTT:YSTS,MLKK,BTTR
                             NULL:BRDS,FLWR,SLTT
                             YSTS:BRDS,FLWR
                             MLKK:SPCS,NULL
                             HNYN:BRDS,FLWR,SLTT,YSTS
                             """;

        Sut.Part1(input).Should().Be(7);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             BRDS:FLWR,SLTT,YSTS
                             FLWR:SLTT,YSTS
                             SLTT:YSTS,MLKK,BTTR
                             NULL:BRDS,FLWR,SLTT
                             YSTS:BRDS,FLWR
                             MLKK:SPCS,NULL
                             HNYN:BRDS,FLWR,SLTT,YSTS
                             """;

        Sut.Part2(input).Should().Be(6);
    }

    [Fact]
    public void Part3()
    {
        const string input = """
                             MEAL:BRDS,CAKE,DOUG
                             BRDS:DOUG,FLWR
                             CAKE:DOUG,FLWR,NULLv2,NULLv3
                             DOUG:FLWR,YSTS,SLTT,NULLv1
                             FLWR:BRDS,DOUG
                             YSTS:SPCS
                             SOUP:BRDS,CAKE,DOUG,FLWR
                             """;

        Sut.Part3(input).Should().Be(3);
    }
}