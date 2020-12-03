﻿using System;
using Core.DonutMaze;

namespace ConsoleApp.Years.Year2019
{
    public class Day20 : Day2019
    {
        public Day20() : base(20)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var mazeSolver = new DonutMazeSolver(Input);
            Console.WriteLine($"Shortest distance from AA to ZZ: {mazeSolver.ShortestStepCount}");

            WritePartTitle();
            var recursiveDonutMazeSolver = new RecursiveDonutMazeSolver(Input);
            Console.WriteLine($"Shortest distance from AA to ZZ: {recursiveDonutMazeSolver.ShortestStepCount}");
        }

        protected override string Input => @"
_                                                                                                           _
_                                  T Z     P       J     A       Y           U                              _
_                                  D Z     C       R     I       Q           D                              _
_   ###############################.#.#####.#######.#####.#######.###########.###########################   _
_   #.#.......#...#.................#...#.#.....#.....#.......#.#.......#.....#.....#...................#   _
_   #.###.#######.###########.#.#.#.###.#.#####.###.#.#.#######.#####.###.#####.#####.#######.###.#.###.#   _
_   #...#.#...#...#.#.#.......#.#.#.....#.#.......#.#.#.#.....#.......#...................#.#...#.#.#.#.#   _
_   ###.#.#.#####.#.#.#.#.#.#.###.#######.#.#.#.###.###.#.###.#.#.#.#########.###.#########.#####.###.###   _
_   #.......#.#.....#.#.#.#.#...#.......#...#.#...#...#.....#.#.#.#.#.......#...#.........#.....#.#.#...#   _
_   ###.#####.#####.#.#####.#########.###.###.#####.#########.#.#####.#.###.#.###.###.#.###.#######.#.###   _
_   #...#.....#.#.#...#...#.#.....#.#...#.#...#.....#.....#...#.....#.#...#...#.#...#.#...#...#.....#...#   _
_   ###.#.###.#.#.###.#.###.###.#.#.###.#.###.#.#.###.#.#.#.#.#.###.#####.#####.#####.#####.###.#######.#   _
_   #...#.#.#...#.........#.#.#.#.....#.#...#.#.#...#.#.#...#.#.#.#.#...........#.#.....#...#...#...#.#.#   _
_   ###.###.#.#########.#####.###.###.#.#.#.#######.###.#.#.###.#.#####.#.###.###.#######.#.#.#####.#.#.#   _
_   #.....#...#.#...#...#.....#.#.#.....#.#.#...#...#...#.#.#.........#.#...#...#.#...#.#.#.....#.#.....#   _
_   ###.#####.#.###.###.#####.#.#.###.#.###.#.#.#.#####.#####.#######.###.###.###.###.#.###.###.#.###.###   _
_   #.#.#.#.....#.#.#...........#...#.#...#...#.#.....#.....#.....#...#.#.#.....#.........#...#.#.#.....#   _
_   #.#.#.###.###.#.#.#########.#.###.#####.#####.#.#####.###.#######.#.#####.###.#########.#####.#####.#   _
_   #.......#.#.........#.#.#.....#.#.#.#.#...#.#.#...#.#.#.#.#.#...#...#.#.....................#.#.#.#.#   _
_   ###.###.#.#####.#####.#.#####.#.###.#.#.###.###.###.#.#.###.#.###.###.###.#######.#####.#.###.#.#.#.#   _
_   #.#...#.#.#.#...#...#...#.#...#.......#...#.#.#...#.....#...#...........#.....#.#...#.#.#.#.........#   _
_   #.#####.#.#.#####.###.###.###.###.###.#.###.#.###.#.#######.#.#####.#####.#####.#.###.#######.###.###   _
_   #.#.#.#.........#.#.....#.......#.#.........#.#...#.....#.#...#...#.#.#.........#.#.#.#.....#.#...#.#   _
_   #.#.#.#.#########.#####.#####.###.#.#.#.#.###.#.#####.#.#.###.#.#.###.#.###.###.###.#.#.###.#.###.#.#   _
_   #.....#.......#...#.....#.#.....#.#.#.#.#...#.....#...#.....#...#...#.....#.#...#.#.....#...#...#.#.#   _
_   ###.#####.#######.#####.#.###.#######.#######.#########.###.#.###.#####.#########.###.#####.#####.#.#   _
_   #...#.#...#.#...#...#.....#.......#.......#.......#.....#...#.#.....#.....#.......#...#.#.#.#.......#   _
_   #.#.#.###.#.###.#.#####.#####.#########.#######.#######.#########.#####.#####.#######.#.#.#######.###   _
_   #.#.#.#.......#...#.....#    Y         M       R       H         J     H    #...#.#...#.......#...#.#   _
_   #.###.#####.###.###.#####    Q         F       C       G         R     Z    ###.#.###.###.#######.#.#   _
_   #...............#.......#                                                   #.#.......#.....#.......#   _
_   ###.#.#####.###.#.#.#.###                                                   #.#.#######.#####.#.#.###   _
_   #...#.#.#...#.....#.#...#                                                 DD....#.#.....#...#.#.#....HG _
_   ###.###.#####.###.#####.#                                                   ###.#.###.###.#########.#   _
_ DD..#.....#.#.#.#.#...#....CC                                                 #.....#...#.#.#...#.#.#.#   _
_   #.#.#.###.#.###.#.#######                                                   #.#######.#.#.#.#.#.#.#.#   _
_   #...#.#.....#...#.#.....#                                                   #.#.#.#.....#...#.#.....#   _
_   ###########.###.#####.###                                                   #.###.#.#.#####.#######.#   _
_   #.......#.........#.....#                                                   #.......#...............#   _
_   #.#####.#.#####.###.###.#                                                   #########################   _
_   #.#.#.....#...#.#.....#..QE                                               PN........................#   _
_   ###.###.###.###.#.#######                                                   ###.#.#.###.#.#.#.#.###.#   _
_   #.....#.#...#...........#                                                   #.#.#.#...#.#.#.#.#...#.#   _
_   #.#.#.#.###.#####.#.#.###                                                   #.#.###.###.#.#####.###.#   _
_ ER..#.#...#.#.#...#.#.#...#                                                   #.#...#.#...#.#.......#..HZ _
_   #########.#.###.#########                                                   #.###.#.###.#########.#.#   _
_   #.....................#..PC                                               FA..#.#.#.#.....#.#.#...#.#   _
_   #.#####.#.###.#.#.###.#.#                                                   #.#.###########.#.#####.#   _
_ KW....#...#.#...#.#.#...#.#                                                   #.#.#.#.....#.#.......#.#   _
_   #.###.#####.###.#####.#.#                                                   #.#.#.###.###.#.#########   _
_   #.#.....#...#.#...#...#.#                                                   #.......#.......#.....#.#   _
_   #.#.#.#####.#.#.###.#.#.#                                                   #####.#######.#.#.#.###.#   _
_   #.#.#.#...#.#...#...#...#                                                   #.#...........#...#......ZU _
_   #######.#####.###########                                                   #.#######.###########.###   _
_   #...#.#.#.#.....#.......#                                                   #...#.....#...#.....#...#   _
_   #.###.#.#.###.#.#####.#.#                                                   #.###.###.###.#.###.#####   _
_ XZ....#.#.#.#.#.#.#.#...#.#                                                   #...#.#.#.#.....#.......#   _
_   #.###.#.#.#.#####.###.#.#                                                   #.#####.#######.###.###.#   _
_   #...#...#.#.#.#.#.#...#..KW                                               XI..................#...#..CC _
_   ###.#.#.#.#.#.#.#.###.###                                                   ###################.#.#.#   _
_   #.....#.................#                                                   #.........#.......#.#.#.#   _
_   ###.#.#.###.#####.#######                                                   #.#####.#.#.###.#.#######   _
_ RC..#.#.#...#.#.#.....#.#..JC                                               TD..#.....#...#.#.#...#...#   _
_   #.###########.#######.#.#                                                   #.###.#.#.###.#.#####.###   _
_   #...#.#.#.........#...#.#                                                   #.#...#.#.#.#...#........PN _
_   #.###.#.###.###.#.#.#.#.#                                                   #########.#.#.###.#####.#   _
_   #...........#...#...#...#                                                   #.#.....#.#.#.........#.#   _
_   #########################                                                   #.#####.###.#############   _
_   #...............#.......#                                                   #.#.........#.......#....VD _
_   ###.#.#########.#.###.###                                                   #.###.#.###.#.#.#.#.###.#   _
_   #.#.#.#...#.........#.#..UD                                               TS....#.#...#...#.#.#.....#   _
_   #.#.###.#######.#.###.#.#                                                   #.#.#.###.#.###.###.###.#   _
_   #...#.....#.#...#.#...#.#                                                 AI..#.#...#.#.#.#.#.....#.#   _
_   #.#####.###.#########.#.#                                                   ###.#.#######.#####.###.#   _
_ FA..#...#.....#...#.#.#...#                                                   #.#.....#...#...#...#....GB _
_   ###.###.#####.###.#.#####                                                   #.#######.#####.#########   _
_   #...#.....#..............ZU                                               WA....#...........#.......#   _
_   #.#.###.#.#.#####.###.#.#                                                   ###.#.#####.###.#.###.###   _
_   #.#.#...#.#.#.#...#...#.#                                                   #.....#.#.....#.#.#.....#   _
_   #.#.#.#.#.#.###.#####.###                                                   #.#.###.#######.#.###.#.#   _
_   #.#.#.#.#.#...#.#.....#.#                                                   #.#.....#.......#...#.#..JC _
_   #.#.#.###.###.#######.#.#                                                   #.#.###.#.#.###.###.###.#   _
_ TS..#.....#...........#...#                                                   #.#.#.#.#.#...#.....#...#   _
_   #.#.#######.#.#.#.#######      E         V     X     K             E G      #####.#########.#.#.#.#.#   _
_   #.#.#.......#.#.#.#.....#      E         D     Z     J             R B      #.#.#.....#.....#.#.#.#.#   _
_   #.#######.#####.#######.#######.#########.#####.#####.#############.#.#######.#.#.###.###.#####.#####   _
_   #.#.#.........#...#...#.....#.....#...#.....#...#...#.........#.#...#...............#.#...#.......#.#   _
_   #.#.#####.###.#####.#####.#####.#.###.#####.#.###.#.#####.#.###.#.#######.#.#.###.###.###.###.#.###.#   _
_   #.#.........#...#.#.............#.#.....#...#.#...#.#...#.#.#...#...#.....#.#.#...#.#.#...#...#...#.#   _
_   #.#.###.#.###.###.#####.###.#.#.#####.###.###.#.###.#.#.###.#.#.###.###.#.#.#.#.#.#.###.###.#.###.#.#   _
_   #.#...#.#.#.....#.......#.#.#.#...#.#...#...#.#.#...#.#.....#.#.....#...#.#.#.#.#.....#.#...#...#...#   _
_   ###.###.###.###.#########.###.###.#.#.#####.#.#.#.###.#####.#.#.#####.#####.###.#######.#.#######.#.#   _
_   #.#...#.#...#.....#.............#.#.........#...#...#.#.....#.#.#...#.#.#.#...#...#.#.#.#...#.....#.#   _
_   #.#####.#######.#############.#.#######.#####.#.###.#.#####.#.###.#.#.#.#.###.#####.#.###########.#.#   _
_   #.#.....#.............#.#.....#...#.......#.#.#.#.#.#.....#.#.....#.#.....#.#.#.........#.#.#.....#.#   _
_   #.#.###.###.#.#.#.#####.###.#.###########.#.#####.#.#.#.#########.#.#####.#.###.#########.#.#.#.###.#   _
_   #...#...#...#.#.#.#.....#...#.......#.......#.#.....#.#.#.#...#...#.#.#.#.................#.#.#.#.#.#   _
_   ###.###.###.###.#######.#####.#.#########.###.#.#.#.#.###.#.###.###.#.#.#.#.#.#########.###.#####.#.#   _
_   #.....#.#...#.#.#.............#...#.#.......#.#.#.#.#.......#.#.#.#.#.....#.#...#.#.............#...#   _
_   #.#.###.#.###.#########.#####.#####.#.#####.#.#.###.###.###.#.###.#.#####.#####.#.#####.#######.#.#.#   _
_   #.#.#...#...#...#.#.#.#.#.#.#.#...#...#.#.....#.#.....#.#...#...#.......#.#.#.#...#...........#.#.#.#   _
_   #.#.#.#.#.#####.#.#.#.###.#.#.#.#.#.#.#.#.#######.#.#.###.#.#.#####.#####.#.#.#########.#.#########.#   _
_   #.#.#.#.#...#.................#.#.#.#.#...#.#...#.#.#.#...#.#...#...#.#.#.#...........#.#.....#.....#   _
_   ###.###.###########.#########.#.###.#####.#.###.###.#####.#####.###.#.#.#.#.#.###.#.#.###.###.#####.#   _
_   #.#.#.#.#.........#...#.........#...#...#.....#...#...#...#.#.......#.......#...#.#.#.#.....#.#.....#   _
_   #.###.#.###.###.#.#####.#.#.###.#####.#####.###.###.#####.#.###.#######.###.#####.#######.###.#####.#   _
_   #.......#...#.#.#.#...#.#.#.#.....#...........#.....#.....#.....#...#.#...#.....#...#.......#.#.....#   _
_   #####.###.#.#.###.###.#######.#######.#####.#####.###.###.###.#####.#.###.#.###.#.#.###.#.#######.#.#   _
_   #.....#...#.#.......................#.....#...#.....#.#.....#.....#.......#.#...#.#...#.#.#.......#.#   _
_   #################################.#.#####.#########.###.#######.#####.###############################   _
_                                    X A     K         W   E       M     Q                                  _
_                                    I A     J         A   E       F     E                                  _
_                                                                                                           _";
    }
}