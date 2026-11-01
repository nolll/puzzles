using Pzl.Everybody.Puzzles.Ece2026;

namespace Tests.Everybody.Ece2026;

public class Ece202605Tests : PuzzleTest<Ece202605>
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             010100100100001101000
                             111101001000001110000
                             101111011000101010011
                             001000101010000100000
                             000110100110011001100
                             000001110111111000000
                             101100010101011110000
                             001101100000001010011
                             001001001111010001001
                             100011011110011010101
                             001100101110010010000
                             """;

        Sut.Part1(input).Should().Be(137);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             010100100100001101000
                             111101001000001110000
                             101111011000101010011
                             001000101010000100000
                             000110100110011001100
                             000001110111111000000
                             101100010101011110000
                             001101100000001010011
                             001001001111010001001
                             100011011110011010101
                             001100101110010010000
                             """;

        Sut.Part2(input).Should().Be(69);
    }

    [Fact]
    public void Part3()
    {
        const string input = "";

        Sut.Part3(input).Should().Be(0);
    }
}