using System;
using Core.SubterraneanSustainability;

namespace ConsoleApp.Years.Year2018
{
    public class Day12 : Day2018
    {
        public Day12() : base(12)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var spreader = new PlantSpreader(Input);
            Console.WriteLine($"Plant score 20: {spreader.PlantScore20}");

            WritePartTitle();
            Console.WriteLine($"Plant score 50 billion generations: {spreader.PlantScore50B}");
        }

        protected override string Input => @"initial state: ##.####..####...#.####..##.#..##..#####.##.#..#...#.###.###....####.###...##..#...##.#.#...##.##..

##.## => #
....# => .
.#.#. => #
..### => .
##... => #
##### => .
###.# => #
.##.. => .
..##. => .
...## => #
####. => .
###.. => .
.#### => #
#...# => #
..... => .
..#.. => .
#..## => .
#.#.# => #
.#.## => #
.###. => .
##..# => .
.#... => #
.#..# => #
...#. => .
#.#.. => .
#.... => .
##.#. => .
#.### => .
.##.# => .
#..#. => #
..#.# => .
#.##. => #";
    }
}