using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq15;

public class Aquaq15Tests
{
    [Test]
    public void CountStepsForOne()
    {
        const string input = "fly,try";

        var result = new Aquaq15().Run(input);

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

        var result = new Aquaq15().Run(input);

        result.Should().Be(45);
    }
}