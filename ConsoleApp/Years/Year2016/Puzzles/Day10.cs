using System;
using Core.BalanceBots;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day10 : Day2016
    {
        public Day10() : base(10)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var simulator = new BotSimulator(FileInput);
            var botId = simulator.FindIdByChips(17, 61);
            return new PuzzleResult($"Id of requested bot: {botId}");
        }

        public override PuzzleResult RunPart2()
        {
            var simulator = new BotSimulator(FileInput);
            var multipliedOutput = simulator.GetMultipliedOutput();
            return new PuzzleResult($"Multiplied output: {multipliedOutput}");
        }
    }
}