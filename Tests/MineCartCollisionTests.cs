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
/->-\        _
|   |  /----\_
| /-+--+-\  |_
| | |  | v  |_
\-+-/  \-+--/_
  \------/   _";

            var detector = new CollisionDetector(input);
            var coords = detector.LocationOfFirstCollision;

            Assert.That(coords, Is.EqualTo("7,3"));
        }
    }
}