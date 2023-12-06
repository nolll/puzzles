using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202108;

public class Aoc202108Tests
{
    [Test]
    public void Part1()
    {
        var puzzle = new SevenSegmentDisplayDecoder(Input.Trim());
        var result = puzzle.GetEasyNumbers();

        result.Should().Be(26);
    }

    [TestCase("abc", "abcd", true)]
    [TestCase("abc", "abde", false)]
    public void IsSubsetOf(string sShort, string sLong, bool expected)
    {
        var decoder = new DigitDecoder(SingleInput);
        var result = DigitDecoder.IsSubsetOf(sShort, sLong);
            
        result.Should().Be(expected);
    }

    [Test]
    public void Part2Single()
    {
        var decoder = new DigitDecoder(SingleInput);
        decoder.DecodedNumber.Should().Be(5353);
    }
        
    [Test]
    public void Part2()
    {
        var puzzle = new SevenSegmentDisplayDecoder(Input.Trim());
        var result = puzzle.GetDecodedSum();

        result.Should().Be(61229);
    }

    private const string SingleInput = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf";
        
    private const string Input = """
be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe
edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc
fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg
fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb
aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea
fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb
dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe
bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef
egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb
gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce
""";
}