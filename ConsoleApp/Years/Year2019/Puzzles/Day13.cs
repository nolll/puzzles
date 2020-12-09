using System;
using Core.ArcadeCabinet;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day13 : Day2019
    {
        public Day13() : base(13)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var arcade1 = new Arcade(FileInput);
            arcade1.Play();

            Console.WriteLine($"Number of block tiles: {arcade1.NumberOfBlockTiles}");

            WritePartTitle();
            var arcade2 = new Arcade(FileInput);
            arcade2.Play(2);
        }
    }
}