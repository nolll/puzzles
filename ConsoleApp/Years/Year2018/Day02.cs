using System;
using Core.Boxes;
using Data.Inputs;

namespace ConsoleApp.Years.Year2018
{
    public class Day02 : Day
    {
        public Day02() : base(2)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var boxChecksumPuzzle = new BoxChecksumPuzzle(InputData.BoxIds);
            Console.WriteLine($"Checksum: {boxChecksumPuzzle.Checksum}");

            var similarIdsPuzzle = new SimilarIdsPuzzle(InputData.BoxIds);
            Console.WriteLine($"Common letters: {similarIdsPuzzle.CommonLetters}");

            WritePartTitle();
        }
    }
}