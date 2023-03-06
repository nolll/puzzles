using NUnit.Framework;

namespace Core.Puzzles.Year2020.Day06;

public class Year2020Day06Tests
{
    [Test]
    public void SumOfAtLeastYesAnswerCounts()
    {
        var reader = new DeclarationFormReader(Input);
        var sum = reader.SumOfAtLeastOneYes;

        Assert.That(sum, Is.EqualTo(11));
    }

    [Test]
    public void SumOfAllAnswerCounts()
    {
        var reader = new DeclarationFormReader(Input);
        var sum = reader.SumOfAllYes;

        Assert.That(sum, Is.EqualTo(6));
    }

    private const string Input = """
abc

a
b
c

ab
ac

a
a
a
a

b
""";
}