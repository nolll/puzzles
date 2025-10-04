namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202420;

public class Aoc202420Tests
{
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

    [Fact]
    public void Part1_1() => Aoc202420.CountCheatsBetterThan(Input, 2, 35).Should().Be(4);

    [Fact]
    public void Part2_1() => Aoc202420.CountCheatsBetterThan(Input, 20, 50).Should().Be(285);

    [Fact]
    public void Part1_2()
    {
        var result = Aoc202420.GetCheats(Input, 2);
        
        var bucket2 = result.Where(o => o.Value == 2).ToList();
        var bucket4 = result.Where(o => o.Value == 4).ToList();
        var bucket6 = result.Where(o => o.Value == 6).ToList();
        var bucket8 = result.Where(o => o.Value == 8).ToList();
        var bucket10 = result.Where(o => o.Value == 10).ToList();
        var bucket12 = result.Where(o => o.Value == 12).ToList();
        var bucket20 = result.Where(o => o.Value == 20).ToList();
        var bucket36 = result.Where(o => o.Value == 36).ToList();
        var bucket38 = result.Where(o => o.Value == 38).ToList();
        var bucket40 = result.Where(o => o.Value == 40).ToList();
        var bucket64 = result.Where(o => o.Value == 64).ToList();
        
        bucket2.Count.Should().Be(14);
        bucket4.Count.Should().Be(14);
        bucket6.Count.Should().Be(2);
        bucket8.Count.Should().Be(4);
        bucket10.Count.Should().Be(2);
        bucket12.Count.Should().Be(3);
        bucket20.Count.Should().Be(1);
        bucket36.Count.Should().Be(1);
        bucket38.Count.Should().Be(1);
        bucket40.Count.Should().Be(1);
        bucket64.Count.Should().Be(1);
    }
    
    [Fact]
    public void Part2_2()
    {
        var rSavings = Aoc202420.GetCheats(Input, 20);
        
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

    private static Aoc202420 Sut => new();
}