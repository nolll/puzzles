using System;
using Core.Boxes;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day02 : Day2018
    {
        public Day02() : base(2)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var boxChecksumPuzzle = new BoxChecksumPuzzle(FileInput);
            Console.WriteLine($"Hash: {boxChecksumPuzzle.Checksum}");

            WritePartTitle();
            var similarIdsPuzzle = new SimilarIdsPuzzle(FileInput);
            Console.WriteLine($"Common letters: {similarIdsPuzzle.CommonLetters}");
        }
    }
}