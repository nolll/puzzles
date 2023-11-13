using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2019.Aoc201924;

public class Aoc201924Tests
{
    [Test]
    public void AfterZeroMinutes()
    {
        const string input = """
....#
#..#.
#..##
..#..
#....
""";

        var simulator = new BugLifeSimulator(input);
        simulator.Run(0);

        simulator.String.Should().Be("....##..#.#..##..#..#....");
    }

    [Test]
    public void AfterOneMinute()
    {
        const string input = """
....#
#..#.
#..##
..#..
#....
""";

        var simulator = new BugLifeSimulator(input);
        simulator.Run(1);

        simulator.String.Should().Be("#..#.####.###.###.##.##..");
    }

    [Test]
    public void AfterTwoMinutes()
    {
        const string input = """
....#
#..#.
#..##
..#..
#....
""";

        var simulator = new BugLifeSimulator(input);
        simulator.Run(2);

        simulator.String.Should().Be("#####....#....#...#.#.###");
    }

    [Test]
    public void AfterThreeMinutes()
    {
        const string input = """
....#
#..#.
#..##
..#..
#....
""";

        var simulator = new BugLifeSimulator(input);
        simulator.Run(3);

        simulator.String.Should().Be("#....####....###.##..##.#");
    }

    [Test]
    public void AfterFourMinutes()
    {
        const string input = """
....#
#..#.
#..##
..#..
#....
""";

        var simulator = new BugLifeSimulator(input);
        simulator.Run(4);

        simulator.String.Should().Be("####.....###..#.....##...");
    }

    [Test]
    public void UntilRepeat_String()
    {
        const string input = """
....#
#..#.
#..##
..#..
#....
""";

        var simulator = new BugLifeSimulator(input);
        simulator.RunUntilRepeat();

        simulator.String.Should().Be("...............#.....#...");
    }

    [Test]
    public void UntilRepeat_BiodiversityRating()
    {
        const string input = """
....#
#..#.
#..##
..#..
#....
""";

        var simulator = new BugLifeSimulator(input);
        simulator.RunUntilRepeat();

        simulator.BiodiversityRating.Should().Be(2129920);
    }

    [Test]
    public void Recursive_BugCount()
    {
        const string input = """
....#
#..#.
#..##
..#..
#....
""";

        var simulator = new RecursiveBugLifeSimulator(input);
        simulator.Run(10);

        simulator.BugCount.Should().Be(99);
    }
}