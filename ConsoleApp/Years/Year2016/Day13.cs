using System;
using Core.CubicleMaze;

namespace ConsoleApp.Years.Year2016
{
    public class Day13 : Day
    {
        public Day13() : base(13)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var maze = new Maze(50, 50, Input, 31, 39);
            Console.WriteLine($"Required number of steps: {maze.RouteLength}");
        }

        private const int Input = 1362;
    }
}