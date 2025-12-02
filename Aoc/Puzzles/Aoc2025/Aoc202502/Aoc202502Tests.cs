namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202502;

public class Aoc202502Tests
{
    private const string Input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,\n1698522-1698528,446443-446449,38593856-38593862,565653-565659,\n824824821-824824827,2121212118-2121212124";

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("1227775554");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("4174379265");

    private static Aoc202502 Sut => new();
}