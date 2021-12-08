using App.Platform;

namespace App.Puzzles.Year2016.Day04
{
    public class Year2016Day04 : Year2016Day
    {
        public override int Day => 4;

        public override PuzzleResult RunPart1()
        {
            var validator = new RoomValidator(FileInput);
            var sum = validator.SumOfIds;
            return new PuzzleResult(sum, 278_221);
        }

        public override PuzzleResult RunPart2()
        {
            var validator = new RoomValidator(FileInput);
            return new PuzzleResult(validator.NorthpoleObjectStorageId, 267);
        }
    }
}