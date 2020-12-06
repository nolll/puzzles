using System;
using Core.GridComputing;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day22 : Day2016
    {
        public Day22() : base(22)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var storageGrid = new StorageGrid(FileInput);
            var pairCount = storageGrid.GetViablePairCount();
            Console.WriteLine($"Number of viable pairs: {pairCount}");

            WritePartTitle();
            var moveCount = storageGrid.MoveStorage();
            Console.WriteLine($"Least number of moves: {moveCount}");
        }
    }
}