using System.Collections;
using Core.MoonTracking;
using NUnit.Framework;

namespace Tests
{
    public class MoonTrackingTests
    {
        [Test]
        public void After1Step()
        {
            var map = @"
<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>";

            var moonTracker = new MoonTracker(map);
            moonTracker.Run(1);
            var moons = moonTracker.Moons;

            Assert.That(moons[0].X, Is.EqualTo(-1));
            Assert.That(moons[0].Y, Is.EqualTo(0));
            Assert.That(moons[0].Z, Is.EqualTo(2));

            Assert.That(moons[0].X, Is.EqualTo(2));
            Assert.That(moons[0].Y, Is.EqualTo(-10));
            Assert.That(moons[0].Z, Is.EqualTo(-7));

            Assert.That(moons[0].X, Is.EqualTo(4));
            Assert.That(moons[0].Y, Is.EqualTo(-8));
            Assert.That(moons[0].Z, Is.EqualTo(8));

            Assert.That(moons[0].X, Is.EqualTo(3));
            Assert.That(moons[0].Y, Is.EqualTo(5));
            Assert.That(moons[0].Z, Is.EqualTo(-1));
        }
    }
}