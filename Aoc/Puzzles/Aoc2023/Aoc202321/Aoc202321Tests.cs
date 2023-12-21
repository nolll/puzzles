using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202321;

public class Aoc202321Tests
{
    private const string Input = """
                                 ...........
                                 .....###.#.
                                 .###.##..#.
                                 ..#.#...#..
                                 ....#.#....
                                 .##..S####.
                                 .##..#...#.
                                 .......##..
                                 .##.#.####.
                                 .##..##.##.
                                 ...........
                                 """;

    [Test]
    public void CountPositionsAfter1() => 
        Aoc202321.CountPositionsAfter(Input, 1).Should().Be(2);

    [Test]
    public void CountPositionsAfter2() => 
        Aoc202321.CountPositionsAfter(Input, 2).Should().Be(4);

    [Test]
    public void CountPositionsAfter3() => 
        Aoc202321.CountPositionsAfter(Input, 3).Should().Be(6);

    //[Test]
    //public void CountPositionsAfter10() => 
    //    Aoc202321.CountPositionsAfter(Input, 10).Should().Be(50);

    //[Test]
    //public void CountPositionsAfter50() =>
    //    Aoc202321.CountPositionsAfter(Input, 50).Should().Be(1594);

    //[Test]
    //public void CountPositionsAfter100() =>
    //    Aoc202321.CountPositionsAfter(Input, 100).Should().Be(6536);

    //[Test]
    //public void CountPositionsAfter500() =>
    //    Aoc202321.CountPositionsAfter(Input, 500).Should().Be(167004);

    //[Test]
    //public void CountPositionsAfter1000() =>
    //    Aoc202321.CountPositionsAfter(Input, 1000).Should().Be(668697);

    //[Test]
    //public void CountPositionsAfter5000() =>
    //    Aoc202321.CountPositionsAfter(Input, 5000).Should().Be(16733044);
}