using Core.Platform;

namespace Core.Puzzles.Year2020.Day10
{
    public class Year2020Day10 : Year2020Day
    {
        public override int Day => 10;

        public override PuzzleResult RunPart1()
        {
            var chain = new PowerAdapterChain(FileInput);
            return new PuzzleResult(chain.DifferenceProduct, 2590);
        }

        public override PuzzleResult RunPart2()
        {
            var chain = new PowerAdapterChain(FileInput);
            var combinations = chain.GetTotalNumberOfCombinations();
            return new PuzzleResult(combinations, 226_775_649_501_184);
        }
    }
}