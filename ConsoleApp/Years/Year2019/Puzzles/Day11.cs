using System;
using Core.ShipPainting;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day11 : Day2019
    {
        public Day11() : base(11)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var robot1 = new PaintRobot(FileInput);
            var result1 = robot1.Paint(false);

            return new PuzzleResult(result1.PaintedPanelCount, 1732);
        }

        public override PuzzleResult RunPart2()
        {
            var robot2 = new PaintRobot(FileInput);
            var result2 = robot2.Paint(true);

            var printout = result2.Printout.Replace('0', ' ').Replace('1', 'X');

            return new PuzzleResult(printout, "ABCLFUHJ");
        }
    }
}