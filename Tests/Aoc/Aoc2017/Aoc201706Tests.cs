using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201706Tests : PuzzleTest<Aoc201706>
{
    [Fact]
    public void StepsUntilRepeat()
    {
        const string input = "0,2,7,0";
        var reallocator = new Aoc201706.MemoryReallocator(input);
        reallocator.Run();

        reallocator.Steps.Should().Be(5);
        reallocator.LoopSize.Should().Be(4);
    }
}