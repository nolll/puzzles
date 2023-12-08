using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202011;

public class Aoc202011Tests
{
    [Test]
    public void NumberOfOccupiedSeatsIsCorrect_FirstAlgorithm()
    {
        const string input = """
                             L.LL.LL.LL
                             LLLLLLL.LL
                             L.L.L..L..
                             LLLL.LL.LL
                             L.LL.LL.LL
                             L.LLLLL.LL
                             ..L.L.....
                             LLLLLLLLLL
                             L.LLLLLL.L
                             L.LLLLL.LL
                             """;

        var simulator = new SeatingSimulatorAdjacentSeats(input);
        simulator.Run();
        var result = simulator.OccupiedSeatCount;

        result.Should().Be(37);
    }

    [Test]
    public void NumberOfOccupiedSeatsIsCorrect_SecondAlgorithm()
    {
        const string input = """
                             L.LL.LL.LL
                             LLLLLLL.LL
                             L.L.L..L..
                             LLLL.LL.LL
                             L.LL.LL.LL
                             L.LLLLL.LL
                             ..L.L.....
                             LLLLLLLLLL
                             L.LLLLLL.L
                             L.LLLLL.LL
                             """;

        var simulator = new SeatingSimulatorVisibleSeats(input);
        simulator.Run();
        var result = simulator.OccupiedSeatCount;

        result.Should().Be(26);
    }
}