namespace ConsoleApp.Puzzles.Year2018.Day02
{
    public class Year2018Day02 : Year2018Day
    {
        public override int Day => 2;

        public override PuzzleResult RunPart1()
        {
            var boxChecksumPuzzle = new BoxChecksumPuzzle(FileInput);
            return new PuzzleResult(boxChecksumPuzzle.Checksum, 5434);
        }

        public override PuzzleResult RunPart2()
        {
            var similarIdsPuzzle = new SimilarIdsPuzzle(FileInput);
            return new PuzzleResult(similarIdsPuzzle.CommonLetters, "agimdjvlhedpsyoqfzuknpjwt");
        }
    }
}