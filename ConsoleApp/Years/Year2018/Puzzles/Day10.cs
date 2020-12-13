using System;
using Core.AlignedStars;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day10 : Day2018
    {
        public Day10() : base(10)
        {
        }

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