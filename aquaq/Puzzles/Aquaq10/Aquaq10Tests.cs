using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq10;

public class Aquaq10Tests
{
    private const string Input = """
s,d,c
A,B,8
B,A,8
B,C,50
B,D,5
C,B,50
C,E,6
D,B,5
D,E,10
E,C,6
""";

    [Test]
    public void SmallestCost()
    {
        var result = Aquaq10.Run(Input, "A", "C");

        Assert.That(result, Is.EqualTo(29));
    }
}