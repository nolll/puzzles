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

            var navigator = new AirDuctNavigator(input);
            var shortestPath = navigator.Run(false);

            Assert.That(shortestPath, Is.EqualTo(14));
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

            var navigator = new AirDuctNavigator(input);
            var shortestPath = navigator.Run(true);

            Assert.That(shortestPath, Is.EqualTo(20));
        }
    }
}