namespace ConsoleApp.Puzzles.Year2018.Day10
{
    public class Year2018Day10 : Year2018Day
    {
        public override int Day => 10;

        public override PuzzleResult RunPart1()
        {
            var finder = new StarMessageFinder(FileInput, 9);
            return new PuzzleResult(finder.Message, CorrectAnswer.Trim());
        }

        public override PuzzleResult RunPart2()
        {
            var finder = new StarMessageFinder(FileInput, 9);
            return new PuzzleResult(finder.IterationCount, 10355);
        }

        private const string CorrectAnswer = @"
#....#..#####...#####...#....#..#####...#####...#....#...####.
#....#..#....#..#....#..#....#..#....#..#....#..#...#...#....#
#....#..#....#..#....#..#....#..#....#..#....#..#..#....#.....
#....#..#....#..#....#..#....#..#....#..#....#..#.#.....#.....
######..#####...#####...######..#####...#####...##......#.....
#....#..#..#....#.......#....#..#....#..#..#....##......#..###
#....#..#...#...#.......#....#..#....#..#...#...#.#.....#....#
#....#..#...#...#.......#....#..#....#..#...#...#..#....#....#
#....#..#....#..#.......#....#..#....#..#....#..#...#...#...##
#....#..#....#..#.......#....#..#####...#....#..#....#...###.#";
    }
}