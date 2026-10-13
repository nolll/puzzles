using Pzl.Aoc.Puzzles.Aoc2019;

namespace Tests.Aoc.Aoc2019;

public class Aoc201909Tests : PuzzleTest<Aoc201909>
{
    [Fact]
    public void ReturnsInputMemoryAsOutputMemory() =>
        string.Join(',', Sut.Run("109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99", 0))
            .Should().Be("109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99");

    [Fact]
    public void Outputs16DigitNumber() => 
        Sut.Run("1102,34915192,34915192,7,4,7,99,0", 0).Last().ToString().Length
            .Should().Be(16);

    [Fact]
    public void ReturnsLargeMiddleNumber() =>
        Sut.Run("104,1125899906842624,99", 0).Last()
            .Should().Be(long.Parse("104,1125899906842624,99".Split(',')[1]));
}