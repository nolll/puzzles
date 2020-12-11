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

            return new PuzzleResult($"First packet Y value sent to NAT: {network.FirstNatPacket.Y}");
        }

        public override PuzzleResult RunPart2()
        {
            var network = new CategorySixNetwork(FileInput);
            network.Run();

            return new PuzzleResult($"First repeated packet Y value sent from NAT: {network.FirstRepeatedNatPacket.Y}");
        }
    }
}