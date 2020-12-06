﻿using System;
using Core.AirDuct;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day24 : Day2016
    {
        public Day24() : base(24)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var navigator1 = new AirDuctNavigator(FileInput, false);
            navigator1.Run();
            Console.WriteLine($"Shortest path: {navigator1.ShortestPath}");

            WritePartTitle();
            var navigator2 = new AirDuctNavigator(FileInput, true);
            navigator2.Run();
            Console.WriteLine($"Shortest path including going back to start: {navigator2.ShortestPath}");
        }
    }
}