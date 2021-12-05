using Core.PassportProcessing;

namespace ConsoleApp.Puzzles.Year2020.Puzzles
{
    public class Year2020Day04 : Year2020Day
    {
        public override int Day => 4;

        public override PuzzleResult RunPart1()
        {
            var processor = new PassportProcessor(FileInput);
            var passportCount = processor.GetNumberOfPassportsThatHasAllFields();
            return new PuzzleResult(passportCount, 210);
        }

        public override PuzzleResult RunPart2()
        {
            var processor = new PassportProcessor(FileInput);
            var passportCount = processor.GetNumberOfValidPassports();
            return new PuzzleResult(passportCount, 131);
        }
    }
}