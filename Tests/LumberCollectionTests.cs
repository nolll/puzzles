using Core.Puzzles.Year2018.Day18;
using NUnit.Framework;

namespace Tests
{
    public class LumberCollectionTests
    {
        [Test]
        public void ResourceValueIsCorrect()
        {
            const string input = @"
.#.#...|#.
.....#|##|
.|..|...#.
..|#.....#
#.#|||#|#|
...#.||...
.|....|...
||...#|.#|
|.||||..|.
...#.|..|.";

            var collection = new LumberCollection(input);
            collection.Run(10);
            Assert.That(collection.ResourceValue, Is.EqualTo(1147));
        }
    }
}