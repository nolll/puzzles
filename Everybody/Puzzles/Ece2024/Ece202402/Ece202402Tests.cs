using FluentAssertions;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202402;

public class Ece202402Tests
{
    [Theory]
    [InlineData("AWAKEN THE POWER ADORNED WITH THE FLAMES BRIGHT IRE", 4)]
    [InlineData("THE FLAME SHIELDED THE HEART OF THE KINGS", 3)]
    [InlineData("POWE PO WER P OWE R", 2)]
    [InlineData("THERE IS THE END", 3)]
    public void CountRunicWords(string input, int expected)
    {
        string[] words = ["THE", "OWE", "MES", "ROD", "HER"];

        var count = Sut.CountRunicWords(words, [input]);

        count.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("AWAKEN THE POWER ADORNED WITH THE FLAMES BRIGHT IRE", 15)]
    [InlineData("THE FLAME SHIELDED THE HEART OF THE KINGS", 9)]
    [InlineData("POWE PO WER P OWE R", 6)]
    [InlineData("THERE IS THE END", 7)]
    [InlineData("QAQAQ", 5)]
    public void CountRunicSymbols(string input, int expected)
    {
        string[] words = ["THE", "OWE", "MES", "ROD", "HER", "QAQ"];

        var count = Sut.CountRunicSymbols(words, [input]);

        count.Should().Be(expected);
    }
    
    [Fact]
    public void CountRunicSymbolsInGrid()
    {
        string[] words = ["THE", "OWE", "MES", "ROD", "RODEO"];
        
        const string scales = """
                              HELWORLT
                              ENIGWDXL
                              TRODEOAL
                              """;

        var count = Sut.CountRunicSymbolsInGrid(words, scales.Split());

        count.Should().Be(10);
    }
    
    private static Ece202402 Sut => new();
}

    