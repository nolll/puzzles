using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq15;

public class Aquaq15Tests
{
    [Fact]
    public void CountStepsForOne()
    {
        const string input = "fly,try";

        var result = new Aquaq15().RunInternal(input, FileReader.ReadCommon("Words.txt"));

        result.Should().Be(3);
    }

    [Fact]
    public void CountStepsForThree()
    {
        const string input = """
                             fly,try
                             try,fly
                             word,maze
                             """;

        var result = new Aquaq15().RunInternal(input, FileReader.ReadCommon("Words.txt"));

        result.Should().Be(45);
    }
}