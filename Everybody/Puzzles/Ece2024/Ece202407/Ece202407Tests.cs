namespace Pzl.Everybody.Puzzles.Ece2024.Ece202407;

public class Ece202407Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             A:+,-,=,=
                             B:+,=,-,+
                             C:=,-,+,+
                             D:=,=,=,+
                             """;

        Sut.Part1(input).Answer.Should().Be("BDCA");
    }
    
    [Fact]
    public void Part2()
    {
        const string track = """
                             S+===
                             -   +
                             =+=-+
                             """;
        
        const string input = """
                             A:+,-,=,=
                             B:+,=,-,+
                             C:=,-,+,+
                             D:=,=,=,+
                             """;

        Sut.SolvePart2(track, input).Should().Be("DCBA");
    }
    
    private static Ece202407 Sut => new();
}