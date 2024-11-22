using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202308;

public class Aoc202308Tests
{
    [Test]
    public void DesertPart1Example1()
    {
        const string input ="""
                            RL
                            
                            AAA = (BBB, CCC)
                            BBB = (DDD, EEE)
                            CCC = (ZZZ, GGG)
                            DDD = (DDD, DDD)
                            EEE = (EEE, EEE)
                            GGG = (GGG, GGG)
                            ZZZ = (ZZZ, ZZZ)
                            """;

        var result = Aoc202308.DesertPath1(input);

        result.Should().Be(2);
    }

    [Test]
    public void DesertPart1Example2()
    {
        const string input = """
                             LLR
                             
                             AAA = (BBB, BBB)
                             BBB = (AAA, ZZZ)
                             ZZZ = (ZZZ, ZZZ)
                             """;

        var result = Aoc202308.DesertPath1(input);

        result.Should().Be(6);
    }

    [Test]
    public void DesertPart2()
    {
        const string input = """
                             LR
                             
                             11A = (11B, XXX)
                             11B = (XXX, 11Z)
                             11Z = (11B, XXX)
                             22A = (22B, XXX)
                             22B = (22C, 22C)
                             22C = (22Z, 22Z)
                             22Z = (22B, 22B)
                             XXX = (XXX, XXX)
                             """;

        var result = Aoc202308.DesertPath2(input);

        result.Should().Be(6);
    }
}