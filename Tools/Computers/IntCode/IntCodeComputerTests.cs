namespace Pzl.Tools.Computers.IntCode;

public class IntCodeComputerTests
{
    [Theory]
    [InlineData("1,0,0,0,99", 2)]
    [InlineData("2,3,0,3,99", 2)]
    [InlineData("2,4,4,5,99,0", 2)]
    [InlineData("1,1,1,4,99,5,6,0,99", 30)]
    public void OutputsAreCorrect(string input, int expectedResult)
    {
        var computer = new ConsoleComputer(input);
        computer.Start();
        var result = computer.Result;
        result.Should().Be(expectedResult);
    }
}