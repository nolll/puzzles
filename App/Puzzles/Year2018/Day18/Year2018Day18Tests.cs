using NUnit.Framework;

namespace App.Puzzles.Year2018.Day18
{
    public class Year2018Day18Tests
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