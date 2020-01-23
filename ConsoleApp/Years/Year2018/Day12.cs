using System;
using Core.SubterraneanSustainability;

namespace ConsoleApp.Years.Year2018
{
    public class Day12 : Day
    {
        public Day12() : base(12)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var spreader = new PlantSpreader(Input);
            Console.WriteLine($"Plant score: {spreader.PlantScore}");
        }

        private const string Input = @"initial state: ##.####..####...#.####..##.#..##..#####.##.#..#...#.###.###....####.###...##..#...##.#.#...##.##..

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