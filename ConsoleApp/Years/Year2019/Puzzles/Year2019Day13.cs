using System;
using Core.ArcadeCabinet;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Year2019Day13 : Year2019Day
    {
        public override int Day => 13;

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