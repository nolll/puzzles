using System;
using Core.RoomValidation;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day04 : Day2016
    {
        public Day04() : base(4)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var validator = new RoomValidator(FileInput);
            var sum = validator.SumOfIds;
            return new PuzzleResult($"Sum of valid room ids: {sum}");
        }

        public override PuzzleResult RunPart2()
        {
            var validator = new RoomValidator(FileInput);
            return new PuzzleResult($"Northpole object storage room: {validator.NorthpoleObjectStorageId}");
        }
    }
}