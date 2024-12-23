using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202420;

public class Aoc202420Tests
{
    private const int BaseCount = 84;
    private const string Input = """
                                 ###############
                                 #...#...#.....#
                                 #.#.#.#.#.###.#
                                 #S#...#.#.#...#
                                 #######.#.#.###
                                 #######.#.#...#
                                 #######.#.###.#
                                 ###..E#...#...#
                                 ###.#######.###
                                 #...###...#...#
                                 #.#####.#.###.#
                                 #.#...#.#.#...#
                                 #.#.#.#.#.#.###
                                 #...#...#...###
                                 ###############
                                 """;

    [Test]
    public void Part1_1()
    {
        Sut.CountCheatsBetterThanPart1(Input, 35).Should().Be(4);
    }
    
    [Test]
    public void Part2_1()
    {
        Sut.CountCheatsBetterThanPart2(Input, 73).Should().Be(7);
    }
    
    [Test]
    public void Part1_2()
    {
        var r = Sut.ScoresWithCheats(Input, 2);
        var rSavings = r.paths.Select(o => r.baseScore - o.Count - 1).ToList();

        var rstr = string.Join(",", r.paths.Count);
        
        var bucket2 = rSavings.Count(o => o == 2);
        var bucket4 = rSavings.Count(o => o == 4);
        var bucket6 = rSavings.Count(o => o == 6);
        var bucket8 = rSavings.Count(o => o == 8);
        var bucket10 = rSavings.Count(o => o == 10);
        var bucket12 = rSavings.Count(o => o == 12);
        var bucket20 = rSavings.Count(o => o == 20);
        var bucket36 = rSavings.Count(o => o == 36);
        var bucket38 = rSavings.Count(o => o == 38);
        var bucket40 = rSavings.Count(o => o == 40);
        var bucket64 = rSavings.Count(o => o == 64);
        
        bucket2.Should().Be(14);
        bucket4.Should().Be(14);
        bucket6.Should().Be(2);
        bucket8.Should().Be(4);
        bucket10.Should().Be(2);
        bucket12.Should().Be(3);
        bucket20.Should().Be(1);
        bucket36.Should().Be(1);
        bucket38.Should().Be(1);
        bucket40.Should().Be(1);
        bucket64.Should().Be(1);
    }
    
    [Test]
    public void Part2_2()
    {
        var rSavings = Sut.GetCheatsPart2(Input, 2);
        
        var bucket50 = rSavings.Where(o => o.Value == 50).ToList();
        var bucket52 = rSavings.Where(o => o.Value == 52).ToList();
        var bucket54 = rSavings.Where(o => o.Value == 54).ToList();
        var bucket56 = rSavings.Where(o => o.Value == 56).ToList();
        var bucket58 = rSavings.Where(o => o.Value == 58).ToList();
        var bucket60 = rSavings.Where(o => o.Value == 60).ToList();
        var bucket62 = rSavings.Where(o => o.Value == 62).ToList();
        var bucket64 = rSavings.Where(o => o.Value == 64).ToList();
        var bucket66 = rSavings.Where(o => o.Value == 66).ToList();
        var bucket68 = rSavings.Where(o => o.Value == 68).ToList();
        var bucket70 = rSavings.Where(o => o.Value == 70).ToList();
        var bucket72 = rSavings.Where(o => o.Value == 72).ToList();
        var bucket74 = rSavings.Where(o => o.Value == 74).ToList();
        var bucket76 = rSavings.Where(o => o.Value == 76).ToList();
        
        bucket50.Count.Should().Be(32);
        bucket52.Count.Should().Be(31);
        bucket54.Count.Should().Be(29);
        bucket56.Count.Should().Be(39);
        bucket58.Count.Should().Be(25);
        bucket60.Count.Should().Be(23);
        bucket62.Count.Should().Be(20);
        bucket64.Count.Should().Be(19);
        bucket66.Count.Should().Be(12);
        bucket68.Count.Should().Be(14);
        bucket70.Count.Should().Be(12);
        bucket72.Count.Should().Be(22);
        bucket74.Count.Should().Be(4);
        bucket76.Count.Should().Be(3);
    }
    
    [Test]
    public void Part2_3()
    {
        var rSavings = Sut.GetCheatsPart2(Input, 2);
        
        var bucket72 = rSavings.Where(o => o.Value == 72).OrderBy(o => o.Key.from.X).ThenBy(o => o.Key.from.Y).ToList();
        
        bucket72.Count.Should().Be(22);
        
    }

    [TestCase(0, 4)]
    [TestCase(1, 2)]
    [TestCase(2, 0)]
    [TestCase(3, 0)]
    [TestCase(4, 4)]
    [TestCase(5, 2)]
    [TestCase(6, 0)]
    [TestCase(7, 0)]
    [TestCase(8, 4)]
    [TestCase(9, 2)]
    [TestCase(10, 0)]
    [TestCase(11, 0)]
    [TestCase(12, 12)]
    [TestCase(13, 10)]
    [TestCase(14, 8)]
    [TestCase(15, 6)]
    [TestCase(16, 4)]
    [TestCase(17, 2)]
    [TestCase(18, 64)]
    [TestCase(19, 38)]
    [TestCase(20, 36)]
    [TestCase(21, 0)]
    [TestCase(22, 12)]
    [TestCase(23, 10)]
    [TestCase(24, 8)]
    [TestCase(25, 0)]
    [TestCase(26, 0)]
    [TestCase(27, 0)]
    [TestCase(28, 4)]
    [TestCase(29, 2)]
    [TestCase(30, 0)]
    [TestCase(31, 0)]
    [TestCase(32, 4)]
    [TestCase(33, 2)]
    [TestCase(34, 0)]
    [TestCase(35, 0)]
    [TestCase(36, 4)]
    [TestCase(37, 2)]
    [TestCase(38, 0)]
    [TestCase(39, 0)]
    [TestCase(40, 4)]
    [TestCase(41, 2)]
    [TestCase(42, 0)]
    [TestCase(43, 0)]
    [TestCase(44, 12)]
    [TestCase(45, 2)]
    [TestCase(46, 0)]
    [TestCase(47, 0)]
    [TestCase(48, 0)]
    [TestCase(49, 0)]
    [TestCase(50, 4)]
    [TestCase(51, 2)]
    [TestCase(52, 0)]
    [TestCase(53, 0)]
    [TestCase(54, 8)]
    [TestCase(55, 6)]
    [TestCase(56, 4)]
    [TestCase(57, 2)]
    [TestCase(58, 0)]
    [TestCase(59, 0)]
    [TestCase(60, 0)]
    [TestCase(61, 0)]
    [TestCase(62, 4)]
    [TestCase(63, 2)]
    [TestCase(64, 0)]
    [TestCase(65, 0)]
    [TestCase(66, 4)]
    [TestCase(67, 2)]
    [TestCase(68, 0)]
    [TestCase(69, 0)]
    [TestCase(70, 8)]
    [TestCase(71, 2)]
    [TestCase(72, 0)]
    [TestCase(73, 0)]
    [TestCase(74, 0)]
    [TestCase(75, 0)]
    [TestCase(76, 0)]
    [TestCase(77, 0)]
    [TestCase(78, 0)]
    [TestCase(79, 0)]
    [TestCase(80, 0)]
    [TestCase(81, 0)]
    [TestCase(82, 0)]
    [TestCase(83, 0)]
    [TestCase(84, 0)]
    public void CheatOne(int index, int savings)
    {
        var results = Sut.CheatOne(Input, index);
        var result = Math.Max(BaseCount - results.Min(o => o.Count), 0);
        result.Should().Be(savings);
    }

    private static Aoc202420 Sut => new();
}