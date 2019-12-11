using System;
using Core.Asteroids;
using Core.ShipPainting;
using Data.Inputs;

namespace ConsoleApp.Years.Year2019
{
    public class Day11 : Day
    {
        public Day11() : base(11)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var robot = new PaintRobot(InputData.ComputerProgramDay11);
            var result = robot.Paint();

            Console.WriteLine($"Panels painted at least once: {result.PaintedPanelCount}");
        }
    }
}