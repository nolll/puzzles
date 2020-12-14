using System;
using Core.CategorySix;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day23 : Day2019
    {
        public Day23() : base(23)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var network = new CategorySixNetwork(FileInput);
            network.Run();

            return new PuzzleResult(network.FirstNatPacket.Y, 17_541);
        }

        public override PuzzleResult RunPart2()
        {
            var network = new CategorySixNetwork(FileInput);
            network.Run();

            return new PuzzleResult(network.FirstRepeatedNatPacket.Y, 12_415);
        }
    }
}