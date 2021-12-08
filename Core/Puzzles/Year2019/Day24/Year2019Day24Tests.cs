using NUnit.Framework;

namespace Core.Puzzles.Year2019.Day24
{
    public class Year2019Day24Tests
    {
        [Test]
        public void AfterZeroMinutes()
        {
            const string input = @"
....#
#..#.
#..##
..#..
#....";

            var simulator = new BugLifeSimulator(input);
            simulator.Run(0);

            Assert.That(simulator.String, Is.EqualTo("....##..#.#..##..#..#...."));
        }

        [Test]
        public void AfterOneMinute()
        {
            const string input = @"
....#
#..#.
#..##
..#..
#....";

            var simulator = new BugLifeSimulator(input);
            simulator.Run(1);

            Assert.That(simulator.String, Is.EqualTo("#..#.####.###.###.##.##.."));
        }

        [Test]
        public void AfterTwoMinutes()
        {
            const string input = @"
....#
#..#.
#..##
..#..
#....";

            var simulator = new BugLifeSimulator(input);
            simulator.Run(2);

            Assert.That(simulator.String, Is.EqualTo("#####....#....#...#.#.###"));
        }

        [Test]
        public void AfterThreeMinutes()
        {
            const string input = @"
....#
#..#.
#..##
..#..
#....";

            var simulator = new BugLifeSimulator(input);
            simulator.Run(3);

            Assert.That(simulator.String, Is.EqualTo("#....####....###.##..##.#"));
        }

        [Test]
        public void AfterFourMinutes()
        {
            const string input = @"
....#
#..#.
#..##
..#..
#....";

            var simulator = new BugLifeSimulator(input);
            simulator.Run(4);

            Assert.That(simulator.String, Is.EqualTo("####.....###..#.....##..."));
        }

        [Test]
        public void UntilRepeat_String()
        {
            const string input = @"
....#
#..#.
#..##
..#..
#....";

            var simulator = new BugLifeSimulator(input);
            simulator.RunUntilRepeat();

            Assert.That(simulator.String, Is.EqualTo("...............#.....#..."));
        }

        [Test]
        public void UntilRepeat_BiodiversityRating()
        {
            const string input = @"
....#
#..#.
#..##
..#..
#....";

            var simulator = new BugLifeSimulator(input);
            simulator.RunUntilRepeat();

            Assert.That(simulator.BiodiversityRating, Is.EqualTo(2129920));
        }

        [Test]
        public void Recursive_BugCount()
        {
            const string input = @"
....#
#..#.
#..##
..#..
#....";

            var simulator = new RecursiveBugLifeSimulator(input);
            simulator.Run(10);

            Assert.That(simulator.BugCount, Is.EqualTo(99));
        }
    }
}