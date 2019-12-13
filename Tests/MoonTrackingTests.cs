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

            Assert.That(moonTracker.Moon0.X, Is.EqualTo(2));
            Assert.That(moonTracker.Moon0.Y, Is.EqualTo(-1));
            Assert.That(moonTracker.Moon0.Z, Is.EqualTo(1));

            Assert.That(moonTracker.Moon1.X, Is.EqualTo(3));
            Assert.That(moonTracker.Moon1.Y, Is.EqualTo(-7));
            Assert.That(moonTracker.Moon1.Z, Is.EqualTo(-4));

            Assert.That(moonTracker.Moon2.X, Is.EqualTo(1));
            Assert.That(moonTracker.Moon2.Y, Is.EqualTo(-7));
            Assert.That(moonTracker.Moon2.Z, Is.EqualTo(5));

            Assert.That(moonTracker.Moon3.X, Is.EqualTo(2));
            Assert.That(moonTracker.Moon3.Y, Is.EqualTo(2));
            Assert.That(moonTracker.Moon3.Z, Is.EqualTo(0));
        }

        [Test]
        public void After5Steps()
        {
            var map = @"
<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>";

            var moonTracker = new MoonTracker(map);
            moonTracker.Run(5);

            Assert.That(moonTracker.Moon0.X, Is.EqualTo(-1));
            Assert.That(moonTracker.Moon0.Y, Is.EqualTo(-9));
            Assert.That(moonTracker.Moon0.Z, Is.EqualTo(2));

            Assert.That(moonTracker.Moon1.X, Is.EqualTo(4));
            Assert.That(moonTracker.Moon1.Y, Is.EqualTo(1));
            Assert.That(moonTracker.Moon1.Z, Is.EqualTo(5));
            
            Assert.That(moonTracker.Moon2.X, Is.EqualTo(2));
            Assert.That(moonTracker.Moon2.Y, Is.EqualTo(2));
            Assert.That(moonTracker.Moon2.Z, Is.EqualTo(-4));
            
            Assert.That(moonTracker.Moon3.X, Is.EqualTo(3));
            Assert.That(moonTracker.Moon3.Y, Is.EqualTo(-7));
            Assert.That(moonTracker.Moon3.Z, Is.EqualTo(-1));
        }

        [Test]
        public void TotalEnergyAfter10Steps()
        {
            var map = @"
<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>";

            var moonTracker = new MoonTracker(map);
            moonTracker.Run(10);

            Assert.That(moonTracker.TotalEnergy, Is.EqualTo(179));
        }
    }
}