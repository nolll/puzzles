using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202402;

public class Ece202402Tests
{
    [TestCase("AWAKEN THE POWER ADORNED WITH THE FLAMES BRIGHT IRE", 4)]
    [TestCase("THE FLAME SHIELDED THE HEART OF THE KINGS", 3)]
    [TestCase("POWE PO WER P OWE R", 2)]
    [TestCase("THERE IS THE END", 3)]
    public void CountRunicWords(string input, int expected)
    {
        string[] words = ["THE", "OWE", "MES", "ROD", "HER"];

        var count = Sut.CountRunicWords(words, [input]);

        count.Should().Be(expected);
    }
    
    [TestCase("AWAKEN THE POWER ADORNED WITH THE FLAMES BRIGHT IRE", 15)]
    [TestCase("THE FLAME SHIELDED THE HEART OF THE KINGS", 9)]
    [TestCase("POWE PO WER P OWE R", 6)]
    [TestCase("THERE IS THE END", 7)]
    [TestCase("QAQAQ", 5)]
    public void CountRunicSymbols(string input, int expected)
    {
        string[] words = ["THE", "OWE", "MES", "ROD", "HER", "QAQ"];

        var count = Sut.CountRunicSymbols(words, [input]);

        count.Should().Be(expected);
    }
    
    [Test]
    public void CountRunicSymbolsInMatrix()
    {
        string[] words = ["THE", "OWE", "MES", "ROD", "RODEO"];
        
        const string scales = """
                              HELWORLT
                              ENIGWDXL
                              TRODEOAL
                              """;

        var count = Sut.CountRunicSymbolsInMatrix(words, scales.Split());

        count.Should().Be(10);
    }
    
    private static Ece202402 Sut => new();
}

    