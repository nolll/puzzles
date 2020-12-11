using Core.MakeFuel;
using Core.WaitingAreaSeating;
using NUnit.Framework;
using NUnit.Framework.Api;
using NUnit.Framework.Constraints;

namespace Tests
{
    public class WaitingAreaSeating
    {
        [Test]
        public void NumberOfOccupiedSeatsIsCorrect()
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

            var simulator = new SeatingSimulator(input);
            simulator.RunUntilStable();
            var result = simulator.OccupiedSeatCount;

            Assert.That(result, Is.EqualTo(37));
        }
    }
}