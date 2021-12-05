﻿using Core.HotelDoor;

namespace ConsoleApp.Puzzles.Year2020.Puzzles
{
    public class Year2020Day25 : Year2020Day
    {
        public override int Day => 25;

        public override PuzzleResult RunPart1()
        {
            var finder = new EncryptionKeyFinder(FileInput);
            var key = finder.FindKey();

            return new PuzzleResult(key, 7269858);
        }

        public override PuzzleResult RunPart2()
        {
            return new EmptyPuzzleResult();
        }
    }
}