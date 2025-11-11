namespace Pzl.Everybody.Puzzles.Ece2025.Ece202506;

public class Ece202506Tests
{
    [Fact]
    public void Part1()
    {
        const string input = "ABabACacBCbca";

        Sut.Part1(input).Answer.Should().Be("5");
    }

    [Fact]
    public void Part2()
    {
        const string input = "ABabACacBCbca";

        Sut.Part2(input).Answer.Should().Be("11");
    }

    [Fact]
    public void Part3()
    {
        const string input = "AABCBABCABCabcabcABCCBAACBCa";

        Sut.Part3(input).Answer.Should().Be("3442321");
    }

    private static Ece202506 Sut => new();
}