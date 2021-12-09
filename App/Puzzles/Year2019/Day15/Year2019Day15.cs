﻿using App.Platform;

namespace App.Puzzles.Year2019.Day15
{
    public class Year2019Day15 : Puzzle
    {
        public override string Comment => "Repair droid";
        public override bool IsSlow => true;

        public override PuzzleResult RunPart1()
        {
            // VERY SLOW
            var droid = new RepairDroid(FileInput);
            var result1 = droid.Run();

            return new PuzzleResult(result1, 424);
        }

        public override PuzzleResult RunPart2()
        {
            var filler = new OxygenFiller(GeneratedMapFromStep1);
            var result = filler.Fill();

            return new PuzzleResult(result, 446);
        }

        private const string GeneratedMapFromStep1 = @"
_ # ############# ### ##### ############# _
_#.#.............#...#.....#.............#_
_#.#.#.#########.###.#.#.#.#########.###.#_
_#...#.......#.#...#...#.#...#.....#.#...#_
_#.#########.#.###.#.###.###.#.###.#.#.## _
_#.....#...#.#.....#.#...#.....#.#.#.#...#_
_ ######.#.#.#.#######.#########.#.#.###.#_
_#.......#...#...#...#.#...#.......#.#...#_
_#.#############.#.#.#.#.#.###.#######.#.#_
_#...#.....#...#...#.#...#...#.........#.#_
_#.#.#.###.#.#######.###.###.#.#########.#_
_#.#.#...#.#...........#.#...#.#...#.....#_
_#.#.###.#.#.#########.###.#####.#.#.#### _
_#.#.....#.#...#...#.....#.#.....#.#.....#_
_#.#######.#####.#.#####.#.#.#####.#####.#_
_#.#...#.#.......#...#.....#.....#.#.....#_
_#.#.#.#.######## ##.#######.#####.###### _
_#.#.#.#.........#.#.#.......#...#.#.....#_
_#.#.#.#.#######.#.#.#.#######.#.#.#.###.#_
_#...#...#.#.....#.#...#.......#.#.....#.#_
_ ########.#.#####.#####.#######.#####.#.#_
_#.....#.....#.....#.#...#.....#.....#.#.#_
_#.###.#.#####.###.#.#####.#.#######.###.#_
_#.#...#.....#.#.#.......#.#.....#...#...#_
_#.#### ####.#.#.#.#####.## ####.#.###.#.#_
_#.#...#...#.#.#...#...#...#.....#.#...#.#_
_#.#.#.#.#.#.#.#####.#.###.#.###.#.###.## _
_#...#...#...#.......#.#...#.#.#.#...#...#_
_#.#############.#####.###.#.#.#.###.###.#_
_#.#...........#.#...#...#.#.#.....#.#...#_
_#.#####.#####.#.#.#.###.#.#.#####.#.#.## _
_#...#...#...#.#...#.#.#.#...#...#.#...#.#_
_ ##.#.###.#.#.#####.#.#.#.###.#.#.#####.#_
_#.#.#.#...#.#.#.......#.#.#...#.#...#...#_
_#.#.#.#.#####.#######.#.###.###.###.#.#.#_
_#.#...#.....#...#...#.#.....#...#...#.#.#_
_#.#####.###.###.#.#.#########.###.###.#.#_
_#...#...#.#.....#.#.#.....#...#.#...#X#.#_
_#.###.###.#######.#.#.###.#.###.###.###.#_
_#.................#...#.....#...........#_
_ ################# ### ##### ########### _
";
    }
}