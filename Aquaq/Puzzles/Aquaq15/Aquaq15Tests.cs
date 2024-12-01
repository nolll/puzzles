using FluentAssertions;
using NUnit.Framework;
using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq15;

public class Aquaq15Tests
{
    [Test]
    public void CountStepsForOne()
    {
        const string input = "fly,try";

        var result = new Aquaq15(input, FileReader.ReadCommon("Words.txt")).RunInternal(input);

        result.Should().Be(3);
    }

    [Test]
    public void CountStepsForThree()
    {
        const string input = """
                             fly,try
                             try,fly
                             word,maze
                             """;

        var result = new Aquaq15(input, FileReader.ReadCommon("Words.txt")).RunInternal(input);

        result.Should().Be(45);
    }
}