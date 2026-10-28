using Pzl.Everybody.Puzzles.Ece2024;

namespace Tests.Everybody.Ece2024;

public class Ece202402Tests : PuzzleTest<Ece202402>
{
    [Theory]
    [InlineData("AWAKEN THE POWER ADORNED WITH THE FLAMES BRIGHT IRE", 4)]
    [InlineData("THE FLAME SHIELDED THE HEART OF THE KINGS", 3)]
    [InlineData("POWE PO WER P OWE R", 2)]
    [InlineData("THERE IS THE END", 3)]
    public void CountRunicWords(string input, int expected) =>
        Sut.CountRunicWords(["THE", "OWE", "MES", "ROD", "HER"], [input]).Should().Be(expected);

    [Theory]
    [InlineData("AWAKEN THE POWER ADORNED WITH THE FLAMES BRIGHT IRE", 15)]
    [InlineData("THE FLAME SHIELDED THE HEART OF THE KINGS", 9)]
    [InlineData("POWE PO WER P OWE R", 6)]
    [InlineData("THERE IS THE END", 7)]
    [InlineData("QAQAQ", 5)]
    public void CountRunicSymbols(string input, int expected) =>
        Sut.CountRunicSymbols(["THE", "OWE", "MES", "ROD", "HER", "QAQ"], [input]).Should().Be(expected);

    [Fact]
    public void CountRunicSymbolsInGrid()
    {
        const string scales = """
                              HELWORLT
                              ENIGWDXL
                              TRODEOAL
                              """;

        Sut.CountRunicSymbolsInGrid(["THE", "OWE", "MES", "ROD", "RODEO"], scales.Split()).Should().Be(10);
    }
}