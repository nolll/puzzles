using System;
using Core.BalanceBots;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Year2016Day10 : Year2016Day
    {
        public override int Day => 10;

        public override PuzzleResult RunPart1()
        {
            var simulator = new BotSimulator(FileInput);
            var botId = simulator.FindIdByChips(17, 61);
            return new PuzzleResult(botId, 118);
        }

        public override PuzzleResult RunPart2()
        {
            var simulator = new BotSimulator(FileInput);
            var multipliedOutput = simulator.GetMultipliedOutput();
            return new PuzzleResult(multipliedOutput, 143153);
        }
    }
}