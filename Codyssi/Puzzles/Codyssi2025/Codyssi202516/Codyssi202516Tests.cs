using System.Numerics;
using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202516;

public class Codyssi202516Tests
{
    private const string Input1 = """
                                 FACE - VALUE 38
                                 ROW 2 - VALUE 71
                                 ROW 1 - VALUE 57
                                 ROW 3 - VALUE 68
                                 COL 1 - VALUE 52
                                 
                                 LURD
                                 """;
    
    private const string Input2 = """
                                  FACE - VALUE 38
                                  COL 32 - VALUE 39
                                  COL 72 - VALUE 12
                                  COL 59 - VALUE 56
                                  COL 77 - VALUE 31
                                  FACE - VALUE 43
                                  COL 56 - VALUE 47
                                  ROW 73 - VALUE 83
                                  COL 15 - VALUE 87
                                  COL 76 - VALUE 57
                                  
                                  ULDLRLLRU
                                  """;
    
    private const string Input3 = """
                                  FACE - VALUE 99
                                  FACE - VALUE 10
                                  ROW 1 - VALUE 20
                                  COL 80 - VALUE 30
                                  FACE - VALUE 40
                                  ROW 2 - VALUE 50
                                  COL 78 - VALUE 60
                                  FACE - VALUE 70
                                  ROW 3 - VALUE 80
                                  COL 77 - VALUE 90
                                  FACE - VALUE 11
                                  ROW 4 - VALUE 21
                                  COL 76 - VALUE 31
                                  FACE - VALUE 41
                                  ROW 5 - VALUE 51
                                  COL 75 - VALUE 61
                                  FACE - VALUE 71
                                  ROW 6 - VALUE 81
                                  COL 74 - VALUE 91
                                  FACE - VALUE 12
                                  ROW 7 - VALUE 22
                                  COL 73 - VALUE 32
                                  FACE - VALUE 42
                                  ROW 8 - VALUE 52
                                  COL 72 - VALUE 62
                                  FACE - VALUE 72
                                  ROW 9 - VALUE 82
                                  COL 71 - VALUE 92
                                  
                                  ULDDRUURDRULRDLLURLDRLURLLL
                                  """;

    [Test]
    public void Part1() => Sut.Part1(Input1, 3).Answer.Should().Be("201474");

    [Test]
    public void Part2_1() => Sut.Part2(Input1, 3).Answer.Should().Be("118727856");
    
    [Test]
    public void Part2_2() => Sut.Part2(Input2, 80).Answer.Should().Be("369594451623936000000");
    
    [Test]
    public void Part2_3() => Sut.Part2(Input3, 80).Answer.Should().Be("41477439119464857600000");

    [Test]
    public void Part3_1() => Sut.Part3(Input1, 3).Answer.Should().Be("59477096746944");
    
    [Test]
    public void Part3_2() => Sut.Part3(Input2, 80).Answer.Should().Be("118479211258970523303936");

    private static Codyssi202516 Sut => new();
}