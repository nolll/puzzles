using NUnit.Framework;

namespace Core.Puzzles.Year2016.Day03;

public class Year2016Day03Tests
{
    [TestCase("12 13 14", true)]
    [TestCase("1 2 5", false)]
    public void ValidateTriangles(string triangleSpec, bool expectedResult)
    {
        var validator = new TriangleValidator();
        var isValid = validator.IsValid(triangleSpec);

        Assert.That(isValid, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ValidHorizontalCount()
    {
        const string input = @"12 13 14
1 2 5";

        var validator = new TriangleValidator();
        var validCount = validator.GetHorizontalValidCount(input);

        Assert.That(validCount, Is.EqualTo(1));
    }

    [Test]
    public void ValidVerticalCount()
    {
        const string input = @"101 301 501
102 302 502
103 303 503
201 401 601
202 402 602
203 403 603";

        var validator = new TriangleValidator();
        var validCount = validator.GetVerticalValidCount(input);

        Assert.That(validCount, Is.EqualTo(6));
    }
}