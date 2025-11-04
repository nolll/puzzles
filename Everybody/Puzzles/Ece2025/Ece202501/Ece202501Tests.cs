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

        Sut.RunPart1(input).Answer.Should().Be("Fyrryn");
    }
    
    [Fact]
    public void Part2()
    {
        const string input = """
                             Vyrdax,Drakzyph,Fyrryn,Elarzris
                             
                             R3,L2,R3,L1
                             """;

        Sut.RunPart2(input).Answer.Should().Be("Elarzris");
    }
    
    [Fact]
    public void Part3()
    {
        const string input = """
                             Vyrdax,Drakzyph,Fyrryn,Elarzris
                             
                             R3,L2,R3,L3
                             """;

        Sut.RunPart3(input).Answer.Should().Be("Drakzyph");
    }

    private Ece202501 Sut => new();
}