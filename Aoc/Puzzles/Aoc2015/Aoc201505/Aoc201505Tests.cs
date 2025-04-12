using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201505;

public class Aoc201505Tests
{
    [TestCase("ugknbfddgicrmopn", true)]
    [TestCase("aaa", true)]
    [TestCase("jchzalrnumimnmhp", false)]
    [TestCase("haegwjzuvuyypxyu", false)]
    [TestCase("dvszwmarrgswjxmb", false)]
    public void NaughtyOrNice_AlgorithmOne(string input, bool expected) => 
        NaughtyOrNiceEvaluator.IsNice1(input).Should().Be(expected);

    [TestCase("qjhvhtzxzqqjkmpb", true)]
    [TestCase("xxyxx", true)]
    [TestCase("uurcxstgmygtbstg", false)]
    [TestCase("ieodomkazucvgmuy", false)]
    public void NaughtyOrNice_AlgorithmTwo(string input, bool expected) => 
        NaughtyOrNiceEvaluator.IsNice2(input).Should().Be(expected);
}