using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq08;

public class Aquaq08Tests
{
    [Test]
    public void DaySixState()
    {
        var result = Aquaq08.Run(Input);

        Assert.That(result.milk, Is.EqualTo(1000));
        Assert.That(result.cereal, Is.EqualTo(500));
    }

    private const string Input = """
date,milk,cereal
2016-01-26,1000,1000
2016-01-27,0,0
2016-01-28,0,0
2016-01-29,0,0
2016-01-30,1000,0
""";
}