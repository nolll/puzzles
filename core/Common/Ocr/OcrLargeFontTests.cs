using NUnit.Framework;

namespace Core.Common.Ocr;

public class OcrLargeFontTests
{
    [TestCase(InputB, 'B')]
    [TestCase(InputG, 'G')]
    [TestCase(InputH, 'H')]
    [TestCase(InputK, 'K')]
    [TestCase(InputP, 'P')]
    [TestCase(InputR, 'R')]
    public void TestReadLetter(string input, char expected)
    {
        var result = OcrLargeFont.ReadLetter(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TestReadString()
    {
        var result = OcrLargeFont.ReadString(Input);

        Assert.That(result, Is.EqualTo("HRP"));
    }

    private const string Input = """
#....#..#####...#####...
#....#..#....#..#....#..
#....#..#....#..#....#..
#....#..#....#..#....#..
######..#####...#####...
#....#..#..#....#.......
#....#..#...#...#.......
#....#..#...#...#.......
#....#..#....#..#.......
#....#..#....#..#.......
""";

    private const string InputB = """
#####...
#....#..
#....#..
#....#..
#####...
#....#..
#....#..
#....#..
#....#..
#####...
""";

    private const string InputG = """
.####...
#....#..
#.......
#.......
#.......
#..###..
#....#..
#....#..
#...##..
.###.#..
""";

    private const string InputH = """
#....#..
#....#..
#....#..
#....#..
######..
#....#..
#....#..
#....#..
#....#..
#....#..
""";

    private const string InputK = """
#....#..
#...#...
#..#....
#.#.....
##......
##......
#.#.....
#..#....
#...#...
#....#..
""";

    private const string InputP = """
#####...
#....#..
#....#..
#....#..
#####...
#.......
#.......
#.......
#.......
#.......
""";

    private const string InputR = """
#####...
#....#..
#....#..
#....#..
#####...
#..#....
#...#...
#...#...
#....#..
#....#..
""";
}