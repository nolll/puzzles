using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq15;

public class Aquaq15Tests
{
    [Test]
    public void CountStepsForOne()
    {
        const string input = "fly,try";

        var result = new Aquaq15().Run(input);

        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void CountStepsForThree()
    {
        const string input =
"""
fly,try
try,fly
word,maze
""";

        var result = new Aquaq15().Run(input);

        Assert.That(result, Is.EqualTo(45));
    }
}