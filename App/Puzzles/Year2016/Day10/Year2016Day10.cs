using App.Platform;

namespace App.Puzzles.Year2016.Day10
{
    public class Year2016Day10 : PuzzleDay
    {
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