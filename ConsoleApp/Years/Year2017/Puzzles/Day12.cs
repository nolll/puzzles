using System;
using Core.DigitalPlumber;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day12 : Day2017
    {
        public Day12() : base(12)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var pipes = new Pipes(FileInput);
            Console.WriteLine($"Number of connections: {pipes.PipesInGroupZero}");

            WritePartTitle();
            Console.WriteLine($"Number of groups: {pipes.GroupCount}");
        }
    }
}