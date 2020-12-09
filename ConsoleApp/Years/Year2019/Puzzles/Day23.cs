using System;
using Core.CategorySix;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day23 : Day2019
    {
        public Day23() : base(23)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var network = new CategorySixNetwork(FileInput);
            network.Run();
            
            Console.WriteLine($"First packet Y value sent to NAT: {network.FirstNatPacket.Y}");

            WritePartTitle();
            Console.WriteLine($"First repeated packet Y value sent from NAT: {network.FirstRepeatedNatPacket.Y}");
        }
    }
}