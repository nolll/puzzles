using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq02Tests : PuzzleTest<Aquaq02>
{
    [Fact]
    public void UniqueNumbers() => Sut.GetUniqueNumbers([1, 4, 3, 2, 4, 7, 2, 6, 3, 6]).ToArray().Should().BeEquivalentTo([1, 4, 7, 2, 6]);
}