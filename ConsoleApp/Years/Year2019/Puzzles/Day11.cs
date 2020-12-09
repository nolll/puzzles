using System;
using Core.ShipPainting;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day11 : Day2019
    {
        public Day11() : base(11)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var robot1 = new PaintRobot(FileInput);
            var result1 = robot1.Paint(false);

            Console.WriteLine($"Panels painted at least once: {result1.PaintedPanelCount}");

            WritePartTitle();
            var robot2 = new PaintRobot(FileInput);
            var result2 = robot2.Paint(true);

            var printout = result2.Printout.Replace('0', ' ').Replace('1', 'X');

            Console.WriteLine("Painted spaceship:");
            Console.WriteLine(printout);
        }
    }
}