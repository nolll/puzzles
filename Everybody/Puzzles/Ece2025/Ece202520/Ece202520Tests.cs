namespace Pzl.Everybody.Puzzles.Ece2025.Ece202520;

public class Ece202520Tests
{
    [Fact]
    public void Part1_1()
    {
        const string input = """
                             T#TTT###T##
                             .##TT#TT##.
                             ..T###T#T..
                             ...##TT#...
                             ....T##....
                             .....#.....
                             """;

        Sut.Part1(input).Answer.Should().Be("7");
    }
    
    [Fact]
    public void Part1_2()
    {
        const string input = """
                             T#T#T#T#T#T
                             .T#T#T#T#T.
                             ..T#T#T#T..
                             ...T#T#T...
                             ....T#T....
                             .....T.....
                             """;

        Sut.Part1(input).Answer.Should().Be("0");
    }
    
    [Fact]
    public void Part1_3()
    {
        const string input = """
                             T#T#T#T#T#T
                             .#T#T#T#T#.
                             ..#T###T#..
                             ...##T##...
                             ....#T#....
                             .....#.....
                             """;

        Sut.Part1(input).Answer.Should().Be("0");
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             TTTTTTTTTTTTTTTTT
                             .TTTT#T#T#TTTTTT.
                             ..TT#TTTETT#TTT..
                             ...TT#T#TTT#TT...
                             ....TTT#T#TTT....
                             .....TTTTTT#.....
                             ......TT#TT......
                             .......#TT.......
                             ........S........
                             """;

        Sut.Part2(input).Answer.Should().Be("32");
    }

    [Fact]
    public void Part3()
    {
        const string input = "";

        Sut.Part3(input).Answer.Should().Be("0");
    }

    private static Ece202520 Sut => new();
}