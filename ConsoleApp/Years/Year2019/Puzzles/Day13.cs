using System;
using Core.ArcadeCabinet;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day13 : Day2019
    {
        public Day13() : base(13)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var arcade1 = new Arcade(FileInput);
            arcade1.Play();

            return new PuzzleResult($"Number of block tiles: {arcade1.NumberOfBlockTiles}");
        }

        public override PuzzleResult RunPart2()
        {
            var arcade2 = new Arcade(FileInput);
            arcade2.Play(2);

            return new MissingPuzzleResult("Investigate this! No message was returned");
        }
    }
}