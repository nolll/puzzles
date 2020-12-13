using System;
using Core.Boxes;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day02 : Day2018
    {
        public Day02() : base(2)
        {
        }

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