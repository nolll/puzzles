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
            var arcade = new Arcade(FileInput);
            arcade.Play();

            return new PuzzleResult(arcade.NumberOfBlockTiles, 226);
        }

        public override PuzzleResult RunPart2()
        {
            var arcade = new Arcade(FileInput);
            arcade.Play(2);

            return new PuzzleResult(arcade.Score, 10800);
        }
    }
}