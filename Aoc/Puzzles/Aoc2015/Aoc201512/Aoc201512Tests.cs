namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201512;

public class Aoc201512Tests
{
    [Theory]
    [InlineData("[1,2,3]", 6)]
    [InlineData("{\"a\":2,\"b\":4}", 6)]
    [InlineData("[[[3]]]", 3)]
    [InlineData("{\"a\":{\"b\":4},\"c\":-1}", 3)]
    [InlineData("{\"a\":[-1,1]}", 0)]
    [InlineData("[-1,{\"a\":1}]", 0)]
    [InlineData("[]", 0)]
    [InlineData("{}", 0)]
    public void CalculatesTheSumOfAllNumbers(string input, int expected)
    {
        var doc = new JsonDoc(input, true);

        doc.Sum.Should().Be(expected);
    }
}