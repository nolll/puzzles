using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace Puzzles.aoc.Puzzles.Aoc2023.Aoc202301;

public class Aoc202301Tests
{
    [Test]
    public void CalibrationNumbersPart1()
    {
        const string input = 
"""
1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet
""";

        var result = Aoc202301.FindCalibrationValuesPart1(input).Sum();

        result.Should().Be(142);
    }
    
    [Test]
    public void CalibrationNumbersPart2()
    {
        const string input =
"""
two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen
""";

        var result = Aoc202301.FindCalibrationValuesPart2(input).Sum();

        result.Should().Be(281);
    }

    [Test]
    public void ReplaceDigits()
    {
        var result = Aoc202301.ReplaceStringDigits("xtwone3four");

        result.Should().Be("x2twone34four");
    }
}