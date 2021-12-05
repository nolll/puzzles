using Core.SantasDigitalList;

namespace ConsoleApp.Puzzles.Year2015.Puzzles.Day08
{
    public class Year2015Day08 : Year2015Day
    {
        public override int Day => 8;

        public override PuzzleResult RunPart1()
        {
            var digitalList = new DigitalList(FileInput);
            return new PuzzleResult(digitalList.CodeMinusMemoryDiff, 1342);
        }

        public override PuzzleResult RunPart2()
        {
            var digitalList = new DigitalList(FileInput);
            return new PuzzleResult(digitalList.EncodedMinusCodeDiff, 2074);
        }
    }
}