namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202301;

public class Aoc202301Tests
{
    [Fact]
    public void CalibrationNumbersPart1()
    {
        const string input = """
                             1abc2
                             pqr3stu8vwx
                             a1b2c3d4e5f
                             treb7uchet
                             """;

        var result = Aoc202301.FindCalibrationNumberPart1(input).Sum();

        result.Should().Be(142);
    }
    
    [Fact]
    public void CalibrationNumbersPart2()
    {
        const string input = """
                             two1nine
                             eightwothree
                             abcone2threexyz
                             xtwone3four
                             4nineeightseven2
                             zoneight234
                             7pqrstsixteen
                             """;

        var result = Aoc202301.FindCalibrationNumberPart2(input).Sum();

        result.Should().Be(281);
    }
}