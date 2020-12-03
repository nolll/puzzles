using System;
using Core.SporificaVirus;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day22 : Day2017
    {
        public Day22() : base(22)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var infection1 = new VirusInfection(LegacyInput);
            var infectionCount1 = infection1.RunPart1(10_000);
            Console.WriteLine($"Infected nodes after 10 000 iterations: {infectionCount1}");

            WritePartTitle();
            var infection2 = new VirusInfection(LegacyInput);
            var infectionCount2 = infection2.RunPart2(10_000_000);
            Console.WriteLine($"Infected nodes after 10 000 000 iterations: {infectionCount2}");
        }

        protected override string LegacyInput => @"
.....###..#....#.#..##...
......##.##...........##.
.#..#..#.#.##.##.........
...#..###..##.#.###.#.#.#
##....#.##.#..####.####..
#..##...#.##.##.....##..#
.#.#......#...####...#.##
###....#######...#####.#.
##..#.####...#.#.##......
##.....###....#.#..#.##.#
.#..##.....#########.##..
##...##.###..#.#..#.#...#
...####..#...#.##.#..####
.#..##......#####..#.###.
...#.#.#..##...#####.....
#..###.###.#.....#.#.###.
##.##.#.#.##.#..#..######
####.##..#.###.#...#..###
.........#####.##.###..##
..#.##.#..#..#...##..#...
###.###.#.#..##...###....
##..#.#.#.#.#.#.#...###..
#..#.#.....#..#..#..##...
........#######.#...#.#..
..##.###.#.##.#.#.###..##";
    }
}