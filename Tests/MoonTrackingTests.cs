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
        public void After2770Steps()
        {
            const string map = @"
<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>";

            var moonTracker = new MoonTracker(map);
            moonTracker.Run(2770);

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
        public void TotalEnergyAfter10Steps()
        {
            const string map = @"
<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>";

            var moonTracker = new MoonTracker(map);
            moonTracker.Run(10);

            Assert.That(moonTracker.TotalEnergy, Is.EqualTo(179));
        }

        [Test]
        public void TotalEnergyAfter100Steps()
        {
            const string map = @"
<x=-8, y=-10, z=0>
<x=5, y=5, z=10>
<x=2, y=-7, z=3>
<x=9, y=-8, z=-3>";

            var moonTracker = new MoonTracker(map);
            moonTracker.Run(100);

            Assert.That(moonTracker.TotalEnergy, Is.EqualTo(1940));
            Assert.That(moonTracker.Moon0.X, Is.EqualTo(8));
            Assert.That(moonTracker.Moon0.Y, Is.EqualTo(-12));
            Assert.That(moonTracker.Moon0.Z, Is.EqualTo(-9));
            Assert.That(moonTracker.Moon1.X, Is.EqualTo(13));
            Assert.That(moonTracker.Moon1.Y, Is.EqualTo(16));
            Assert.That(moonTracker.Moon1.Z, Is.EqualTo(-3));
            Assert.That(moonTracker.Moon2.X, Is.EqualTo(-29));
            Assert.That(moonTracker.Moon2.Y, Is.EqualTo(-11));
            Assert.That(moonTracker.Moon2.Z, Is.EqualTo(-1));
            Assert.That(moonTracker.Moon3.X, Is.EqualTo(16));
            Assert.That(moonTracker.Moon3.Y, Is.EqualTo(-13));
            Assert.That(moonTracker.Moon3.Z, Is.EqualTo(23));
            Assert.That(moonTracker.Moon0.Vx, Is.EqualTo(-7));
            Assert.That(moonTracker.Moon0.Vy, Is.EqualTo(3));
            Assert.That(moonTracker.Moon0.Vz, Is.EqualTo(0));
            Assert.That(moonTracker.Moon1.Vx, Is.EqualTo(3));
            Assert.That(moonTracker.Moon1.Vy, Is.EqualTo(-11));
            Assert.That(moonTracker.Moon1.Vz, Is.EqualTo(-5));
            Assert.That(moonTracker.Moon2.Vx, Is.EqualTo(-3));
            Assert.That(moonTracker.Moon2.Vy, Is.EqualTo(7));
            Assert.That(moonTracker.Moon2.Vz, Is.EqualTo(4));
            Assert.That(moonTracker.Moon3.Vx, Is.EqualTo(7));
            Assert.That(moonTracker.Moon3.Vy, Is.EqualTo(1));
            Assert.That(moonTracker.Moon3.Vz, Is.EqualTo(1));
        }

        [Test]
        public void CycleLengthIs2772()
        {
            const string map = @"
<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>";

            var moonTracker = new MoonTracker(map);
            moonTracker.RunUntilRepeat();

            Assert.That(moonTracker.Iterations, Is.EqualTo(2772));
        }

        [Test]
        public void CycleLengthIs4686774924()
        {
            const string map = @"
<x=-8, y=-10, z=0>
<x=5, y=5, z=10>
<x=2, y=-7, z=3>
<x=9, y=-8, z=-3>";

            var moonTracker = new MoonTracker(map);
            moonTracker.RunUntilRepeat();

            Assert.That(moonTracker.Iterations, Is.EqualTo(4686774924));
        }
    }
}