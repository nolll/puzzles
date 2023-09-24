using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2015.Day05;

public class Year2015Day05Tests
{
    [TestCase("ugknbfddgicrmopn", true)]
    [TestCase("aaa", true)]
    [TestCase("jchzalrnumimnmhp", false)]
    [TestCase("haegwjzuvuyypxyu", false)]
    [TestCase("dvszwmarrgswjxmb", false)]
    public void NaughtyOrNice_AlgorithmOne(string input, bool expected)
    {
        var isNice = NaughtyOrNiceEvaluator.IsNice1(input);

        Assert.That(isNice, Is.EqualTo(expected));
    }

    [TestCase("qjhvhtzxzqqjkmpb", true)]
    [TestCase("xxyxx", true)]
    [TestCase("uurcxstgmygtbstg", false)]
    [TestCase("ieodomkazucvgmuy", false)]
    public void NaughtyOrNice_AlgorithmTwo(string input, bool expected)
    {
        var isNice = NaughtyOrNiceEvaluator.IsNice2(input);

        Assert.That(isNice, Is.EqualTo(expected));
    }
}