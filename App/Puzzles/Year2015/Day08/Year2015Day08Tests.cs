using NUnit.Framework;

namespace App.Puzzles.Year2015.Day08;

public class Year2015Day08Tests
{
    [Test]
    public void CodeToMemoryDifference()
    {
        const string input = @"
""""
""abc""
""aaa\""aaa""
""\x27""
";

        var digitalList = new DigitalList(input);

        Assert.That(digitalList.CodeMinusMemoryDiff, Is.EqualTo(12));
    }

    [Test]
    public void EncodedToCodeDifference()
    {
        const string input = @"
""""
""abc""
""aaa\""aaa""
""\x27""
";

        var digitalList = new DigitalList(input);

        Assert.That(digitalList.EncodedMinusCodeDiff, Is.EqualTo(19));
    }
}