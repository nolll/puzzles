namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202018;

public class Aoc202018Tests
{
    [Theory]
    [InlineData("1 + 2 * 3 + 4 * 5 + 6", 71)]
    [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
    [InlineData("2 * 3 + (4 * 5)", 26)]
    [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
    [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12_240)]
    [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13_632)]
    [InlineData("(3 * (6 * 4 * 2 * 2 + 3) + 9) + 4 + (6 * 2 + (8 + 4 * 8 * 4 + 8)) + 5", 719)]
    [InlineData("(5 + (2 + 9 * 2) * 3) * (6 * 3 * 4 * 3 * 9 + (6 + 3 * 8 + 9 + 6 + 2)) + 8 * (7 * 3 + 3 * 9) * (6 + 6)", 426_853_152)]
    public void SumIsCorrect(string input, long expected)
    {
        var calculator = new HomeworkCalculator();
        var sum = calculator.Sum(input, MathPrecedence.Order);

        sum.Should().Be(expected);
    }

    [Fact]
    public void SumofAllIsCorrect()
    {
        const string input = """
                             1 + 2 * 3 + 4 * 5 + 6
                             1 + (2 * 3) + (4 * (5 + 6))
                             2 * 3 + (4 * 5)
                             5 + (8 * 3 + 9 + 3 * 4 * 3)
                             5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))
                             ((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2
                             """;

        const int expected = 26_457;

        var calculator = new HomeworkCalculator();
        var sum = calculator.SumOfAll(input.Trim(), MathPrecedence.Order);

        sum.Should().Be(expected);
    }

    [Theory]
    [InlineData("1 + 2 * 3 + 4 * 5 + 6", 231)]
    [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
    [InlineData("2 * 3 + (4 * 5)", 46)]
    [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
    [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060)]
    [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340)]
    public void SumWithAdditionPrecedenceIsCorrect(string input, long expected)
    {
        var calculator = new HomeworkCalculator();
        var sum = calculator.Sum(input, MathPrecedence.Addition);

        sum.Should().Be(expected);
    }
}