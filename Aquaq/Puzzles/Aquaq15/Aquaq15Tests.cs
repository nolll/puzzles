using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq15;

public class Aquaq15Tests
{
    [Fact]
    public void CountStepsForOne()
    {
        const string input = "fly,try";

        Sut.Solve(input, FileReader.ReadCommon("Words.txt")).Should().Be(3);
    }

    [Fact]
    public void CountStepsForThree()
    {
        const string input = """
                             fly,try
                             try,fly
                             word,maze
                             """;

        Sut.Solve(input, FileReader.ReadCommon("Words.txt")).Should().Be(45);
    }

    private static Aquaq15 Sut => new();
}