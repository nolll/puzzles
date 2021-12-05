using System;
using Core.CategorySix;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Year2019Day23 : Year2019Day
    {
        public override int Day => 23;

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