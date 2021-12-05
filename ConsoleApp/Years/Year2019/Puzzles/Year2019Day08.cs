using System;
using Core.SpaceImages;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Year2019Day08 : Year2019Day
    {
        public override int Day => 8;

        public override PuzzleResult RunPart1()
        {
            var image = new SpaceImage(FileInput);
            var checksum = image.Checksum;
            return new PuzzleResult(checksum, 1716);
        }

        public override PuzzleResult RunPart2()
        {
            var image = new SpaceImage(FileInput);
            var printedImage = image.Print();
            return new PuzzleResult(printedImage.Trim(), CorrectAnswer.Trim());
        }

        private const string CorrectAnswer = @"
X  X XXXX  XX  XXX  X   X
X X  X    X  X X  X X   X
XX   XXX  X  X XXX   X X 
X X  X    XXXX X  X   X  
X X  X    X  X X  X   X  
X  X X    X  X XXX    X  
";
    }
}