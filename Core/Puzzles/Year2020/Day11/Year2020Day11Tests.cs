using NUnit.Framework;

namespace Core.Puzzles.Year2020.Day11
{
    public class Year2020Day11Tests
    {
        [Test]
        public void NumberOfOccupiedSeatsIsCorrect_FirstAlgorithm()
        {
            const string input = @"
L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";

            var simulator = new SeatingSimulatorAdjacentSeats(input);
            simulator.Run();
            var result = simulator.OccupiedSeatCount;

            Assert.That(result, Is.EqualTo(37));
        }

        [Test]
        public void NumberOfOccupiedSeatsIsCorrect_SecondAlgorithm()
        {
            const string input = @"
L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";

            var simulator = new SeatingSimulatorVisibleSeats(input);
            simulator.Run();
            var result = simulator.OccupiedSeatCount;

            Assert.That(result, Is.EqualTo(26));
        }
    }
}