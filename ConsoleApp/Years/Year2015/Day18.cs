﻿using System;
using Core.AnimatedLights;

namespace ConsoleApp.Years.Year2015
{
    public class Day18 : Day2015
    {
        public Day18() : base(18)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var gif = new AnimatedGif(Input);
            gif.RunAnimation(100);
            Console.WriteLine($"Lights switched on: {gif.LightCount}");

            WritePartTitle();
            var gif2 = new AnimatedGif(Input, true);
            gif2.RunAnimation(100);
            Console.WriteLine($"Lights switched on, when corners are always lit: {gif2.LightCount}");
        }

        protected override string Input => @"
###.##..##.#..#.##...#..#.####..#.##.##.##..###...#....#...###..#..###..###.#.#.#..#.##..#...##.#..#
.#...##.#####..##.......#..####.###.##.#..###.###.....#.#.####.##.###..##...###....#.##.....#.#.#.##
.....#.#.....#..###..####..#.....##.#..###.####.#.######..##......#####.#.##.#########.###..#.##.#.#
...###......#.#..###..#.#.....#.##..#.##..###...#.##.#..#..#.##.#..##......##.##.##.######...#....##
.###.....#...#.#...####.#.###..#..####.#..#.##..####...##.#...#..###...###...####..##....####.##..#.
..#....#...#.......#..###.###....#.##..#.....###.#.##.#....#.#....##.##..#.##.#..###.###.##.##..##.#
##..#####.#.#....#.#...#.#.####..#....#..#....#.#..#.#####...#..##.#.....#.##..##.####......#.#.##..
.#..##..#.#.###..##..##...#....##...#..#.#..##.##..###.####.....#.####.#.....##.#.##...#..####..#...
#.#####.......#####...#...####.#.#.#....#.###.#.##.#####..#.###.#..##.##.#.##....#.##..#....####.#.#
#.##...#####....##.#.#.....##......##.##...#.##.##...##...###.###.##.#.####.####.##..#.##.#.#.####..
#.##.##....###.###.#..#..##.##.#..#.#..##..#.#...#.##........###..#...##.#.#.##.......##.....#...###
###..#.#..##.##.#.#.#...#..#...##.##.#.########.......#.#...#....########..#.#.###..#.#..#.##..#####
####.#.#...#.##.##..#.#...#....#..###..#.#.#.####.#.##.##.#..##..##..#..#####.####.##..########..##.
.#.#...#..##.#..#..###.#..####.......##.#.#.#.##.#####..#..##...#.##...#..#....#..#..###..####.#....
..#.#...#....##...#####..#..#...###.###.....#.###.#....#.#..##...#.##.##.####.#.#.#..#.##.#....#.#..
#....###.####.##..#.#.###..###.##.##..#.#...###..#.##.#####.##.#######..#.#...##.#..........####.###
#.#####.#......#.#......#.....##...##.#.#########.#......##..##..##.#..##.##..#....##...###...#.#...
#..#..##..###.#.#.#.#.....###.#.####.##.##....#.#..##....#.#..#.####..###.##...#######.#####.##.#.#.
..###.#........##.#...###..#.##..#.#....##.#......#..#.##..#.#..#.#..#.####.#####..###.##..#.##.#...
##.###....#..##...#..#.#......##..#...#..#.####..#.##...##.####.#...#..###...#.#.#....###.##..#.#...
..##.##.#.##..##.#..#.###...##..##..#....##..##...####.#..####.###...#.....#..#.##..##..###..#.#...#
#.#....#.....#...##.#...####..#..##..##.####..##..##...####...#....##.#.#######..##.#......######.#.
#.#...###.######.######..##..##....#.#......#......#.#.##.#.##.#.#.#...#...#....#.#.#.#..#.##..#...#
####.###.#.#.##..#.##.#...#.##...#.##.##...#.....#.#..#.####.##..######.#..#.#..##....#.#.#..#.#.#.#
..##......#.#...#.##.##..##..##..#..##..#########.#..###..###.##...#..##.#..#.#.#.######..#....#.#..
..##.##.#...###.#...##..######.##.#..####..#..#.#.##.####.##.##.#...##....#...###.##.####..#....#.#.
####...###..#.#.##.#.#....###..##.#.#..########..#...#.#...#.##....##.##...#.....#.#.....#.....#....
.#.###############....#.##..###..#.####.#.##.##..#..#.#...###...##..##.##.#.....##...###.###.....#..
.###..#..##.##..####.#.###.##.##..#..##....#.#......#......##.#...#.#...#..##.#.#...#...#.##..#.##..
###.#.#.########.#.#..####.#..##.#.##.##.###.##..######...#..##.##.#..#.#...#.##..#####.....#.#.#..#
.##.##..#.#...#####.#.#.###...##...####...#......#...#..####..#.##..........#..#.#..###....######.##
..#####...#.#.#.#..#.##..#...#.#..#.##...##..##.##.#.##.#..#.#...#.......##.#...###.....#...#.#.#.##
##.##.#..######.##...#.....#.###.#..##.#.#.#..####.#....##.#....####...##....#.#.##.#..###.##.##..##
.###.##.#..#.###.####..#.##..####.#.#.##..###.#######.###.###...####........##....###.#...#.#.####.#
........#..#.#..##..########..........#.##.#..##.#...#.....####....##..#..#.#####.###...#...#.##.###
.....#..##.####...##.#####..######.##.#.###.####.##.##.#..##.##.######.##......#..#.####..##....#.##
##...####....#.##.##.###....#.#...#.####..##.#.##.#.#...####.#.#.#.#...##.###...##...###...######.##
.#....#.#.####...#.##.....##...###.#.#.##...##.#####....#.######.#.#....##..##...##....##.#.##.#.#.#
.###..###.#.......#.#######..#.#.#.######....#.#####.#.....#.#########...#....##...##.####.#..#.....
##.#..##..##.....#..##...#..##.##.#..#.#####.##.##.#.##.##...##.######.####..#.##..#####.##...##..#.
#.###...##.#.#.#.##....#.#.##.##..#....#...#.#.........#..#..####..####.####..#.##.##.#....####..##.
.#..######..#####.####.##.#.....#.#.#####..##..###.#.#.#..#.#...#.#######..##....##.##...#######..#.
#...#....#.#.##..#####..#########..#.....#...##.#.#.###...#####..##...##...####.......#######.#..###
.#......#...##.###..#....#...#.#.....#.#...##.#.#..#..###.##.###.#.##..##...#.##......#.###..#.#..##
.#....####...###..#.....##..#...#.#.###.#.#.##...#.##.##.#.#.#..####..###.#.#.#.##.#.#...#..#...####
......##.##.#...#####.##..#.###..#.#####..##.#..##.###......#...#...#..#......###.######...#.#.##..#
###..#...#.##..###.#....##...#..#####.#.#..#.###...#####.#....##..####.#.##...#.#...##..#.#.#.#..#.#
...##.#.##.##..#.#.#.###.#.#...#.....###.###.##...#.###.##...##..#..###.#..##.##..###.#....###..##..
.##.#..###..###.##.##...#..#####...#.....#####.##..####...#.##.#.#..##.#.#.#....###.....#....##.....
######.#..#.#..#....#.###...####.####.#.........#..##.#..##..##.....#..#.##.##...#...#####.#.##..#.#
.##.###...####....#.####...#####..#..#...#..#.....###.#..#.###..#.###.#.......##.####..#.##.#...##..
........#.#.##.#.....#####.###......##..#.##.#..#...####.#...#..###.#.#...##..#.#...#.####...#.#.###
.#..#.##..##...######.###.##.#.#...#.#.#.#.##..##..##.#.##..#....#.##...#.##.##...##....##.###.##.#.
##...#...#...###.#.#...#...#..###......##.#.#....##..##.#..##.#.######...#..##.#.##.#.#....#.##.##..
...#..###.#....#...#.##..##.#.##.#..###.##..#.##..####.#########....#.....##.#.##.##..##.##.######.#
#.##.#..##.......###...#.###....###.#..####..##.#####.##.###....##....#.###...####..#.#.#.##.....###
.......#...#...##.#...##.#.#..#.##..##.#....###...##.#####...#.........#.......###.##.#.#.###....##.
###.#.##.##.....#.#..#.#..####.####..#..###..........####.#.##...#######.###..#####..#.....#..###..#
#...##.##..####.##.###.#.#######..###.#..#######..#.##.####...#..#.##.####..####.#.#.......####.#...
...#.##..#..#..##........#.#..#..#.#....#.###.#.###..#.......###..#.....#....#..##.#...#.###...##.#.
###.##..#.##.#.#####..#.##.####....#####..###.#.#..#...#...###.#.##..#.#.#.....#.####.#.#.#.#.#.#...
..##..##..#..##.##.#...#..#....####....#...#..####..#.....######.###.####.#....##....##.#.#.###....#
.#.#.#.##..####..#.....#.####.#....#.....#....#.##..#.#..#.#...#.#.#.#..#..#..##.#....####.......#..
..##.##..###......#...#..##...#.###.####.#...#.####..#.#.#.....#.#...####...#.########.##.#.#.#..###
#....#.##.....##.###.##.###..#.####.....####.##...#..##.###...###..###.#....####.#..#..#..#.#..##.#.
.#.#.##....#.##......#.#..###.#....###....#......#.#.##.##.#########..##..#...#.####..#...####..#..#
.#.#.......##.#.##.#...#...#.##.#..#.#.#.##....#..###.###.##.#.#...##.#..#..##....#..###.#...#.#.##.
#.##.#....####...#..##..#.#.#.#.##.#...#####.#...#..#..#.####.####.#.#....#......##..##..###...#..##
..##.###..##.####..#..#..##...###.#.#.#######.####...####......##.##..#...#.##...##....#..#..#.....#
....#..#..#.#.####.#...##..#....####.#..####...#.#...###...#..#..##...#....##...#.....#.#..#.#.#...#
...#.#.#.##..##.###..#.######....####.###...##...###.#...##.####..#.#..#.#..#.##.....#.#.#..##......
.#.##.##.....##.#..###.###.##....#...###.#......#...##.###.#.##.##...###...###...#.######..#......#.
###..#...#......#..##...#....##.#..###.##.####..##..##....####.#...#.#....##..#.#######..#.#.#####..
##...#####..####..##....#.#.###.##.#..#.#..#.....###...###.#####.....#..##.#......#...#.###.##.##...
...#.#.#..#.###..#.#.#....##.#.#..####.##.#.####.#.#.#...#....##....#.##.####..###.#.#...##.#..#..##
#.#.#..#.##..##.##.#...##.#....#...###..##..#.#######.#.###..##......##.#..###.########.#.##..#.#.##
######.###....##..#..#...####....#.#.#..#...#..######.#.#.##..##....##....##.##.##...#..#.####.#.#..
#####.###..#..###......##...##.####.#.#.#.###.......##..##.####..##.####.#..#..####..#.####.#####...
##.#.#.###..##.#.##.#.#.#.##.#...##........###.#.##..####....###.#.####.####.#.......##.##.##...##..
#.#..###...#..##.....##.#..#.#..##..######.#####...###.#.......###...#..##..#..#..##.#.#....#..#..#.
#.#..####.###..#...#...#...#.###..#.#.#.#.#.#.#..#....#.##.##.##..###..####.#..##..##.###.###....##.
#..#.##.#####........#..#.##.#..##.#...#....#..#.##..###..##..##.##..#..##.#.#...#.#.##.#.##....#.#.
.......##..#.....#..#.#.....#.##...####.###..####..#.#.#.#..#.....#....##...#..#.##..###.#.#....#...
#...###########.##.....##...###.#.##.##..####.##...#.####.#####.#####.####...###.##...##..#.#.###..#
....#.#.###.####.###...#...#.#..###.#.#.##...#..#.#.#..#.####..#..###.######.#.####.###...###.#.##.#
.....#..#..########...#.#.#.#.#.#.#.#..###.##..####...##.#.#.#...##..#####.##.#...#.####.#######.##.
.......#...#.#..#..#...#..#..##.....#.##....##.##...##..##.##...##...#.#..#.##.#.###.#.####.#.#..##.
.####...#...#.#.#....##..........##.##.###.##.#.#..#.#.#......########.#...#.####.##.###..##...####.
#.#.#...##.###..##..#..#.....####.#.....##.##.#..#.#.###.#..#######...##..#.#..#.#..############.###
.##..####.#..#.....###..#..#.#.....#.#.#...##.##.#....#..#..###.#...#....#.#...####..#.....###.####.
..#...#.###.###....##.#..#.##..####.##.#.##.##.##...###.####..#.#.#.##.#.#.#..###..##.##.##.##.#..##
#...............##.....######.#.#####.##.#....#.#..#.##...#.##....#........##.##...#.##.##.#..#.##.#
#..##..#.#.#.##.#..#.#.##.##...#...#..#.#.##..#.#...###...##...###..#####.#.#..#..#.#..#.#.##...##.#
.#######.#.....##...#.#.####.######.#..#......#....##.#.#..#..###.#...###...#....#.#..#.##.#...#.#..
#.###......##.#.##..#.###.###..####..##....#..###......##..##..#####.####....#...###.....###.#..#...
###...#....###.#..#.###.##...###.##.......##.##.#.#.#....####....###..##.###...#..##....#.#.##..##..
.##.......##.######.#.#..#..##....#####.###.#.##.....####....#......####....#.##.#.##..#.##...##.#.#
.#.###...#.#.#.##.###..###...##..#.##.##..##..#.....###.#..#.##.##.####........##.#####.#.#....#...#
##...##..#.##.#######.###.#.##.#####....##.....##.#.....#.#.##.#....#.##.#....##.#..#.###..#..#.#...
.#..#.#.#.#...#.##...###.##.#.#...###.##...#.#..###....###.#.###...##..###..#..##.##....###...###.##";
    }
}