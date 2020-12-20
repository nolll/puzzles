using Core.ImageJigsaw;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day20 : Day2020
    {
        public Day20() : base(20)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var puzzle = new ImageJigsawPuzzle(FileInput);
            return new PuzzleResult(puzzle.ProductOfCornerTileIds, 8_425_574_315_321);
        }

        public override PuzzleResult RunPart2()
        {
            var puzzle = new ImageJigsawPuzzle(FileInput);
            return new PuzzleResult(puzzle.NumberOfHashesThatAreNotPartOfASeaMonster, 1841);
        }
    }
}