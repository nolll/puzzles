using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Ocr;

public class OcrLargeFontTests
{
    [TestCase(InputB, 'B')]
    [TestCase(InputG, 'G')]
    [TestCase(InputH, 'H')]
    [TestCase(InputK, 'K')]
    [TestCase(InputP, 'P')]
    [TestCase(InputR, 'R')]
    [TestCase(InputSpace, ' ')]
    public void TestReadLetter(string input, char expected) =>
        OcrLargeFont.ReadLetter(input)
            .Should().Be(expected);

    [Test]
    public void TestReadString() =>
        OcrLargeFont.ReadString(Input)
            .Should().Be("HRP");

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

    private const string InputSpace = """
                                      ........
                                      ........
                                      ........
                                      ........
                                      ........
                                      ........
                                      ........
                                      ........
                                      ........
                                      ........
                                      """;
}