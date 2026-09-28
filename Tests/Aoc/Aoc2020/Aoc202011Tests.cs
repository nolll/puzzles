using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202011Tests
{
    [Fact]
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

        var simulator = new Aoc202011.SeatingSimulatorAdjacentSeats(input);
        simulator.Run();
        var result = simulator.OccupiedSeatCount;

        result.Should().Be(37);
    }

    [Fact]
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

        var simulator = new Aoc202011.SeatingSimulatorVisibleSeats(input);
        simulator.Run();
        var result = simulator.OccupiedSeatCount;

        result.Should().Be(26);
    }
}