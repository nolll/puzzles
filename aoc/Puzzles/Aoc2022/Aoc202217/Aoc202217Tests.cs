using FluentAssertions;
using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2022.Aoc202217;

public class Aoc202217Tests
{
    [Test]
    public void Part1()
    {
        var tetris = new Tetris();
        var result = tetris.Part1(Input, 2022);

        result.Should().Be(3068);
    }

    [Test]
    public void Part2()
    {
        var tetris = new Tetris();
        var result = tetris.Run(Input, 1_000_000_000_000);

        result.Should().Be(1_514_285_714_288);
    }

    [Test]
    public void CycleFinder_NoCycle()
    {
        var input = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var result = CycleFinder.FindRepeatCycle(input, 2);

        result.Index.Should().Be(0);
        result.Length.Should().Be(0);
    }

    [Test]
    public void CycleFinder_CycleFound()
    {
        var input = new[] { 7, 8, 9, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 6, 7 };

        var result = CycleFinder.FindRepeatCycle(input, 2, 11);

        // does not find the start of the sequence, but the first instance of the sequence found
        // the sequence starts at index 3 (value 1) but the search start is returned, index 6 (value 4)
        // the sequence found id 4, 5, 1, 2, 3
        result.Index.Should().Be(6);
        result.Length.Should().Be(5);
    }

    private const string Input = ">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>";
}