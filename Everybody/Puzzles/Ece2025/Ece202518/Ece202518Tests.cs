namespace Pzl.Everybody.Puzzles.Ece2025.Ece202518;

public class Ece202518Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             Plant 1 with thickness 1:
                             - free branch with thickness 1
                             
                             Plant 2 with thickness 1:
                             - free branch with thickness 1
                             
                             Plant 3 with thickness 1:
                             - free branch with thickness 1
                             
                             Plant 4 with thickness 17:
                             - branch to Plant 1 with thickness 15
                             - branch to Plant 2 with thickness 3
                             
                             Plant 5 with thickness 24:
                             - branch to Plant 2 with thickness 11
                             - branch to Plant 3 with thickness 13
                             
                             Plant 6 with thickness 15:
                             - branch to Plant 3 with thickness 14
                             
                             Plant 7 with thickness 10:
                             - branch to Plant 4 with thickness 15
                             - branch to Plant 5 with thickness 21
                             - branch to Plant 6 with thickness 34
                             """;

        Sut.Part1(input).Answer.Should().Be("774");
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             Plant 1 with thickness 1:
                             - free branch with thickness 1
                             
                             Plant 2 with thickness 1:
                             - free branch with thickness 1
                             
                             Plant 3 with thickness 1:
                             - free branch with thickness 1
                             
                             Plant 4 with thickness 10:
                             - branch to Plant 1 with thickness -25
                             - branch to Plant 2 with thickness 17
                             - branch to Plant 3 with thickness 12
                             
                             Plant 5 with thickness 14:
                             - branch to Plant 1 with thickness 14
                             - branch to Plant 2 with thickness -26
                             - branch to Plant 3 with thickness 15
                             
                             Plant 6 with thickness 150:
                             - branch to Plant 4 with thickness 5
                             - branch to Plant 5 with thickness 6
                             
                             
                             1 0 1
                             0 0 1
                             0 1 1
                             """;

        Sut.Part2(input).Answer.Should().Be("324");
    }

    private static Ece202518 Sut => new();
}