using System;
using Core.SporificaVirus;

namespace ConsoleApp.Years.Year2017
{
    public class Day22 : Day
    {
        public Day22() : base(22)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var infection1 = new VirusInfection(Input);
            var infectionCount1 = infection1.RunPart1(10_000);
            Console.WriteLine($"Infected nodes after 10 000 iterations: {infectionCount1}");

            WritePartTitle();
            var infection2 = new VirusInfection(Input);
            var infectionCount2 = infection2.RunPart2(10_000_000);
            Console.WriteLine($"Infected nodes after 10 000 000 iterations: {infectionCount2}");
        }

        private const string Input = @"
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