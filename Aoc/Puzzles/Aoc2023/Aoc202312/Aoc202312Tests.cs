using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202312;

public class Aoc202312Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             ???.### 1,1,3
                             .??..??...?##. 1,1,3
                             ?#?#?#?#?#?#?#? 1,3,1,6
                             ????.#...#... 4,1,1
                             ????.######..#####. 1,6,5
                             ?###???????? 3,2,1
                             """;

        var result = new Aoc202312(input).RunFunctions.First()();

        result.Answer.Should().Be("21");
    }

    //[Test]
    //public void Part2()
    //{
    //    const string input = """
    //                         ???.### 1,1,3
    //                         .??..??...?##. 1,1,3
    //                         ?#?#?#?#?#?#?#? 1,3,1,6
    //                         ????.#...#... 4,1,1
    //                         ????.######..#####. 1,6,5
    //                         ?###???????? 3,2,1
    //                         """;

    //    var result = new Aoc202312(input).RunFunctions.Last()();

    //    result.Answer.Should().Be("525152");
    //}

    [TestCase("???.### 1,1,3", 1)]
    [TestCase(".??..??...?##. 1,1,3", 4)]
    [TestCase("?###???????? 3,2,1", 10)]
    public void CombinationCount(string input, int expected)
    {
        var result = Aoc202312.CombinationCount(input);

        result.Should().Be(expected);
    }

    [TestCase("???.### 1,1,3", 1)]
    //[TestCase(".??..??...?##. 1,1,3", 16384)]
    //[TestCase("?#?#?#?#?#?#?#? 1,3,1,6", 1)]
    //[TestCase("????.#...#... 4,1,1", 16)]
    //[TestCase("????.######..#####. 1,6,5", 2500)]
    //[TestCase("?###???????? 3,2,1", 506250)]
    public void CombinationCountPart2(string input, int expected)
    {
        var result = Aoc202312.CombinationCount(input, true);

        result.Should().Be(expected);
    }

    [Test]
    public void BuildString()
    {
        var result = Aoc202312.BuildString([1, 2, 3], [1, 2]);

        result.Should().Be(".#..##...");
    }
}