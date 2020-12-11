using System;
using Core.AircraftBoarding;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day05 : Day2020
    {
        public Day05() : base(5)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var processor = new BoardingCardProcessor(FileInput);
            return new PuzzleResult($"The boarding card with the highest id is {processor.HighestId}");
        }

        public override PuzzleResult RunPart2()
        {
            var processor = new BoardingCardProcessor(FileInput);
            var mySeat = processor.FindMySeat();
            return new PuzzleResult($"The id of my seat is {mySeat.Id}");
        }
    }
}