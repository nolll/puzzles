using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day03;

public class Year2022Day06Tests
{
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void Part1(string input, int expected)
    {
        var result = TuningTrouble.FindMarker(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void Part2(string input, int expected)
    {
        var result = TuningTrouble.FindMessage(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}