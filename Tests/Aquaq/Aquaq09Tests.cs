using System.Numerics;
using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq09Tests : PuzzleTest<Aquaq09>
{
    private const string Input = """
                                 2
                                 4
                                 8                    
                                 """;

    [Fact]
    public void MultiplyLargeNumbers() => Sut.Solve(Input).Should().Be(new BigInteger(64));
}