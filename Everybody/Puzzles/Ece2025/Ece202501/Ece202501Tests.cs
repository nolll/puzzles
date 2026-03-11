namespace Pzl.Everybody.Puzzles.Ece2025.Ece202501;

public class Ece202501Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             Vyrdax,Drakzyph,Fyrryn,Elarzris

                             R3,L2,R3,L1
                             """;

        Sut.Part1(input).Should().Be("Fyrryn");
    }
    
    [Fact]
    public void Part2()
    {
        const string input = """
                             Vyrdax,Drakzyph,Fyrryn,Elarzris
                             
                             R3,L2,R3,L1
                             """;

        Sut.Part2(input).Should().Be("Elarzris");
    }
    
    [Fact]
    public void Part3()
    {
        const string input = """
                             Vyrdax,Drakzyph,Fyrryn,Elarzris
                             
                             R3,L2,R3,L3
                             """;

        Sut.Part3(input).Should().Be("Drakzyph");
    }

    private Ece202501 Sut => new();
}