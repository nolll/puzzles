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
            return new PuzzleResult(controller.LitCount, 377_891);
        }

        public override PuzzleResult RunPart2()
        {
            var controller = new ChristmasLightsController();
            controller.RunCommands(FileInput, true);
            return new PuzzleResult(controller.TotalBrightness, 14_110_788);
        }
    }
}