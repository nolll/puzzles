using System;
using Core.DigitalPlumber;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day12 : Day2017
    {
        public Day12() : base(12)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var pipes = new Pipes(FileInput);
            return new PuzzleResult($"Number of connections: {pipes.PipesInGroupZero}");
        }

        public override PuzzleResult RunPart2()
        {
            var pipes = new Pipes(FileInput);
            return new PuzzleResult($"Number of groups: {pipes.GroupCount}");
        }
    }
}