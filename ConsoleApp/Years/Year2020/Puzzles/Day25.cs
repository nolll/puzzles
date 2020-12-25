using Core.HotelDoor;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day25 : Day2020
    {
        public Day25() : base(25)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var finder = new EncryptionKeyFinder(FileInput);
            var key = finder.FindKey();

            return new PuzzleResult(key);
        }

        public override PuzzleResult RunPart2()
        {
            return new EmptyPuzzleResult();
        }
    }
}