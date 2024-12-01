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

        var result = new Aoc202312().RunPart1(input);

        result.Answer.Should().Be("21");
    }

    [Test]
    public void Part2()
    {
        const string input = """
                             ???.### 1,1,3
                             .??..??...?##. 1,1,3
                             ?#?#?#?#?#?#?#? 1,3,1,6
                             ????.#...#... 4,1,1
                             ????.######..#####. 1,6,5
                             ?###???????? 3,2,1
                             """;

        var result = new Aoc202312().RunPart2(input);

        result.Answer.Should().Be("525152");
    }

    [TestCase("???.### 1,1,3", 1)]
    [TestCase(".??..??...?##. 1,1,3", 4)]
    [TestCase("?#?#?#?#?#?#?#? 1,3,1,6", 1)]
    [TestCase("????.#...#... 4,1,1", 1)]
    [TestCase("????.######..#####. 1,6,5", 4)]
    [TestCase("?###???????? 3,2,1", 10)]
    public void CombinationCount(string input, int expected)
    {
        var result = Aoc202312.CombinationCount(input);

        result.Should().Be(expected);
    }

    [TestCase("#.#??????? 1,1,4", 3)]
    [TestCase("##..??#??##?? 2,8", 2)]
    [TestCase("#???.?????? 2,2", 5)]
    [TestCase("##??##??#?.?.??. 10,1", 3)]
    public void SelectedRealData(string input, int expected)
    {
        var result = Aoc202312.CombinationCount(input);

        result.Should().Be(expected);
    }

    [TestCase("???.### 1,1,3", 1)]
    [TestCase(".??..??...?##. 1,1,3", 16384)]
    [TestCase("?#?#?#?#?#?#?#? 1,3,1,6", 1)]
    [TestCase("????.#...#... 4,1,1", 16)]
    [TestCase("????.######..#####. 1,6,5", 2500)]
    [TestCase("?###???????? 3,2,1", 506250)]
    public void CombinationCountPart2(string input, int expected)
    {
        var result = Aoc202312.CombinationCount(input, true);

        result.Should().Be(expected);   
    }

    [TestCase("????.???????#?#.? 1,5", 108778)]
    public void RealCombinationCountPart2(string input, int expected)
    {
        var result = Aoc202312.CombinationCount(input, true);

        result.Should().Be(expected);
    }
}