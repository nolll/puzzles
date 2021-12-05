namespace ConsoleApp.Puzzles.Year2018.Puzzles.Day03
{
    public class Year2018Day03 : Year2018Day
    {
        public override int Day => 3;

        public override PuzzleResult RunPart1()
        {
            var claimsOverlapCountPuzzle = new ClaimsOverlapCountPuzzle(FileInput);
            return new PuzzleResult(claimsOverlapCountPuzzle.OverlapCount, 118_223);
        }

        public override PuzzleResult RunPart2()
        {
            var claimThatDoesNotOverlap = new ClaimThatDoesNotOverlapPuzzle(FileInput);
            return new PuzzleResult(claimThatDoesNotOverlap.ClaimId, 412);
        }
    }
}