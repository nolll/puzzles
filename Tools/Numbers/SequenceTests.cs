namespace Pzl.Tools.Numbers;

public class SequenceTests
{
    [Theory]
    [InlineData("0 3 6 9 12 15", 18)]
    [InlineData("1 3 6 10 15 21", 28)]
    [InlineData("10 13 16 21 30 45", 68)]
    [InlineData("-1 -2 -3 -4 -5 -6", -7)]
    public void NextNumber(string input, long expected) => 
        Sequence.Next(input.Split(' ').Select(long.Parse)).Should().Be(expected);

    [Theory]
    [InlineData("0 3 6 9 12 15", -3)]
    [InlineData("1 3 6 10 15 21", 0)]
    [InlineData("10 13 16 21 30 45", 5)]
    [InlineData("-1 -2 -3 -4 -5 -6", 0)]
    public void PrevNumber(string input, long expected) => 
        Sequence.Previous(input.Split(' ').Select(long.Parse)).Should().Be(expected);
}