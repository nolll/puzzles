using NUnit.Framework;

namespace Core.Puzzles.Year2015.Day05;

public class Year2015Day05Tests
{
    [TestCase("ugknbfddgicrmopn", true)]
    [TestCase("aaa", true)]
    [TestCase("jchzalrnumimnmhp", false)]
    [TestCase("haegwjzuvuyypxyu", false)]
    [TestCase("dvszwmarrgswjxmb", false)]
    public void NaughtyOrNice_AlgorithmOne(string input, bool expected)
    {
        var evaluator = new NaughtyOrNiceEvaluator();
        var isNice = evaluator.IsNice1(input);

        Assert.That(isNice, Is.EqualTo(expected));
    }

    [TestCase("qjhvhtzxzqqjkmpb", true)]
    [TestCase("xxyxx", true)]
    [TestCase("uurcxstgmygtbstg", false)]
    [TestCase("ieodomkazucvgmuy", false)]
    public void NaughtyOrNice_AlgorithmTwo(string input, bool expected)
    {
        var evaluator = new NaughtyOrNiceEvaluator();
        var isNice = evaluator.IsNice2(input);

        Assert.That(isNice, Is.EqualTo(expected));
    }
}