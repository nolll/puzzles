namespace Pzl.Aquaq.Puzzles.Aquaq30;

public class Aquaq30Tests
{
    [Theory]
    [InlineData("11010", 2)]
    [InlineData("110", 0)]
    [InlineData("00101011010", 3)]
    public void CountValidStartingMoves(string input, int expected)
    {
        var result = new CardFlipper().CountValidStartingMoves(input);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("11010", 0, ".0010")]
    [InlineData("11010", 1, "0.110")]
    [InlineData("11010", 3, "111.1")]
    public void Flip(string input, int index, string expected)
    {
        var result = CardFlipper.Flip(input, index);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(".0010", true)]
    [InlineData("0.110", false)]
    [InlineData("111.1", true)]
    public void CanBeSolved(string input, bool expected)
    {
        var inputArray = input.ToCharArray();
        var cardFlipper = new CardFlipper();
        var result = cardFlipper.CanBeSolved(inputArray);

        result.Should().Be(expected);
    }
}