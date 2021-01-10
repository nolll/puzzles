using Core.MineCarts;
using NUnit.Framework;

namespace Tests
{
    public class MineCartCollisionTests
    {
        [Test]
        public void LocationOfFirstCollision()
        {
            const string input = @"
_/->-\        _
_|   |  /----\_
_| /-+--+-\  |_
_| | |  | v  |_
_\-+-/  \-+--/_
_  \------/   _";

            var detector = new CollisionDetector(input);
            detector.RunCarts();
            var coords = detector.LocationOfFirstCollision;

            var str = $"{coords.X},{coords.Y}";
            Assert.That(str, Is.EqualTo("7,3"));
        }

        [Test]
        public void LocationOfLastCart()
        {
            const string input = @"
_/>-<\  _
_|   |  _
_| /<+-\_
_| | | v_
_\>+</ |_
_  |   ^_
_  \<->/_";

            var detector = new CollisionDetector(input);
            detector.RunCarts();
            var coords = detector.LocationOfLastCart;

            var str = $"{coords.X},{coords.Y}";
            Assert.That(str, Is.EqualTo("6,4"));
        }
    }
}