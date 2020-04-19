using Core.AirDuct;
using NUnit.Framework;

namespace Tests
{
    public class AirDuctTests
    {
        [Test]
        public void FindsClosestRoute()
        {
            const string input = @"
###########
#0.1.....2#
#.#######.#
#4.......3#
###########";

            var navigator = new AirDuctNavigator(input, false);
            navigator.Run();

            Assert.That(navigator.ShortestPath, Is.EqualTo(14));
        }

        [Test]
        public void FindsClosestRouteAndGoesBackToStart()
        {
            const string input = @"
###########
#0.1.....2#
#.#######.#
#4.......3#
###########";

            var navigator = new AirDuctNavigator(input, true);
            navigator.Run();

            Assert.That(navigator.ShortestPath, Is.EqualTo(20));
        }
    }
}