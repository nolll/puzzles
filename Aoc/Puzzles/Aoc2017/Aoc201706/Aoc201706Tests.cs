namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201706;

public class Aoc201706Tests
{
    [Fact]
    public void StepsUntilRepeat()
    {
        const string input = "0,2,7,0";
        var reallocator = new MemoryReallocator(input);
        reallocator.Run();

        reallocator.Steps.Should().Be(5);
        reallocator.LoopSize.Should().Be(4);
    }
}