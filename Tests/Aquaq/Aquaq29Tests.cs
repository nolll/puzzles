using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq29Tests : PuzzleTest<Aquaq29>
{
    private readonly List<int> _input = [1, 45, 777, 1245, 10, 97, 2099];

    [Fact]
    public void CountGoodNumbers() => Sut.CountGoodNumbers(_input).Should().Be(4);
}