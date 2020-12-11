using Core.ChristmasLights;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day06 : Day2015
    {
        public Day06() : base(6)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var controller = new ChristmasLightsController();
            controller.RunCommands(FileInput, false);
            return new PuzzleResult($"Lit lights: {controller.LitCount}");
        }

        public override PuzzleResult RunPart2()
        {
            var controller = new ChristmasLightsController();
            controller.RunCommands(FileInput, true);
            return new PuzzleResult($"Total brightness: {controller.TotalBrightness}");
        }
    }
}