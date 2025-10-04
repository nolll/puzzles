namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201505;

public class Aoc201505Tests
{
    [Theory]
    [InlineData("ugknbfddgicrmopn", true)]
    [InlineData("aaa", true)]
    [InlineData("jchzalrnumimnmhp", false)]
    [InlineData("haegwjzuvuyypxyu", false)]
    [InlineData("dvszwmarrgswjxmb", false)]
    public void NaughtyOrNice_AlgorithmOne(string input, bool expected) => 
        NaughtyOrNiceEvaluator.IsNice1(input).Should().Be(expected);

    [Theory]
    [InlineData("qjhvhtzxzqqjkmpb", true)]
    [InlineData("xxyxx", true)]
    [InlineData("uurcxstgmygtbstg", false)]
    [InlineData("ieodomkazucvgmuy", false)]
    public void NaughtyOrNice_AlgorithmTwo(string input, bool expected) => 
        NaughtyOrNiceEvaluator.IsNice2(input).Should().Be(expected);
}