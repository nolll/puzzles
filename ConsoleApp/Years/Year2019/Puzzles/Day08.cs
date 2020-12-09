using System;
using Core.SpaceImages;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day08 : Day2019
    {
        public Day08() : base(8)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var image = new SpaceImage(FileInput);
            var checksum = image.Checksum;
            Console.WriteLine($"Hash: {checksum}");

            WritePartTitle();
            Console.WriteLine(image.Print());
        }
    }
}