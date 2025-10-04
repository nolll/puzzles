namespace Pzl.Tools.Ocr;

public class OcrSmallFontTests
{
    [Theory]
    [InlineData(InputA, 'A')]
    [InlineData(InputB, 'B')]
    [InlineData(InputC, 'C')]
    [InlineData(InputE, 'E')]
    [InlineData(InputF, 'F')]
    [InlineData(InputG, 'G')]
    [InlineData(InputH, 'H')]
    [InlineData(InputI, 'I')]
    [InlineData(InputJ, 'J')]
    [InlineData(InputK, 'K')]
    [InlineData(InputL, 'L')]
    [InlineData(InputO, 'O')]
    [InlineData(InputP, 'P')]
    [InlineData(InputR, 'R')]
    [InlineData(InputU, 'U')]
    [InlineData(InputY, 'Y')]
    [InlineData(InputZ, 'Z')]
    [InlineData(InputSpace, ' ')]
    public void TestReadLetter(string input, char expected) => OcrSmallFont.ReadLetter(input).Should().Be(expected);

    [Fact]
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