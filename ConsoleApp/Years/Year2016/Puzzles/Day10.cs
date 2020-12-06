using System;
using Core.BalanceBots;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day10 : Day2016
    {
        public Day10() : base(10)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var simulator = new BotSimulator(FileInput);
            var botId = simulator.FindIdByChips(17, 61);
            Console.WriteLine($"Id of requested bot: {botId}");

            WritePartTitle();
            var multipliedOutput = simulator.GetMultipliedOutput();
            Console.WriteLine($"Multiplied output: {multipliedOutput}");
        }
    }
}