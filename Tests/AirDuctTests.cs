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

            var robot = new AirDuctRobotTemp(input);
        }
    }
}