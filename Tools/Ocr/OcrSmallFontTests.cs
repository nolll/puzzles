using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Ocr;

public class OcrSmallFontTests
{
    [TestCase(InputA, 'A')]
    [TestCase(InputB, 'B')]
    [TestCase(InputC, 'C')]
    [TestCase(InputE, 'E')]
    [TestCase(InputF, 'F')]
    [TestCase(InputG, 'G')]
    [TestCase(InputH, 'H')]
    [TestCase(InputI, 'I')]
    [TestCase(InputJ, 'J')]
    [TestCase(InputK, 'K')]
    [TestCase(InputL, 'L')]
    [TestCase(InputO, 'O')]
    [TestCase(InputP, 'P')]
    [TestCase(InputR, 'R')]
    [TestCase(InputU, 'U')]
    [TestCase(InputY, 'Y')]
    [TestCase(InputZ, 'Z')]
    [TestCase(InputSpace, ' ')]
    public void TestReadLetter(string input, char expected) => OcrSmallFont.ReadLetter(input).Should().Be(expected);

    [Test]
    public void TestReadString() => OcrSmallFont.ReadString(Input).Should().Be("ABC");

    private const string Input = """
                                 .##..###...##..
                                 #..#.#..#.#..#.
                                 #..#.###..#....
                                 ####.#..#.#....
                                 #..#.#..#.#..#.
                                 #..#.###...##..
                                 """;

    private const string InputA = """
                                  .##..
                                  #..#.
                                  #..#.
                                  ####.
                                  #..#.
                                  #..#.
                                  """;

    private const string InputB = """
                                  ###..
                                  #..#.
                                  ###..
                                  #..#.
                                  #..#.
                                  ###..
                                  """;

    private const string InputC = """
                                  .##..
                                  #..#.
                                  #....
                                  #....
                                  #..#.
                                  .##..
                                  """;

    private const string InputE = """
                                  ####.
                                  #....
                                  ###..
                                  #....
                                  #....
                                  ####.
                                  """;

    private const string InputF = """
                                  ####.
                                  #....
                                  ###..
                                  #....
                                  #....
                                  #....
                                  """;

    private const string InputG = """
                                  .##..
                                  #..#.
                                  #....
                                  #.##.
                                  #..#.
                                  .###.
                                  """;

    private const string InputH = """
                                  #..#.
                                  #..#.
                                  ####.
                                  #..#.
                                  #..#.
                                  #..#.
                                  """;

    private const string InputI = """
                                  .###.
                                  ..#..
                                  ..#..
                                  ..#..
                                  ..#..
                                  .###.
                                  """;


    private const string InputJ = """
                                  ..##.
                                  ...#.
                                  ...#.
                                  ...#.
                                  #..#.
                                  .##..
                                  """;

    private const string InputK = """
                                  #..#.
                                  #.#..
                                  ##...
                                  #.#..
                                  #.#..
                                  #..#.
                                  """;

    private const string InputL = """
                                  #....
                                  #....
                                  #....
                                  #....
                                  #....
                                  ####.
                                  """;

    private const string InputO = """
                                  .##..
                                  #..#.
                                  #..#.
                                  #..#.
                                  #..#.
                                  .##..
                                  """;

    private const string InputP = """
                                  ###..
                                  #..#.
                                  #..#.
                                  ###..
                                  #....
                                  #....
                                  """;

    private const string InputR = """
                                  ###..
                                  #..#.
                                  #..#.
                                  ###..
                                  #.#..
                                  #..#.
                                  """;

    private const string InputU = """
                                  #..#.
                                  #..#.
                                  #..#.
                                  #..#.
                                  #..#.
                                  .##..
                                  """;

    private const string InputY = """
                                  #...#
                                  #...#
                                  .#.#.
                                  ..#..
                                  ..#..
                                  ..#.."
                                  """;

    private const string InputZ = """
                                  ####.
                                  ...#.
                                  ..#..
                                  .#...
                                  #....
                                  ####.
                                  """;

    private const string InputSpace = """
                                      .....
                                      .....
                                      .....
                                      .....
                                      .....
                                      .....
                                      """;
}