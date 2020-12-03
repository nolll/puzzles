using System;
using Core.ChristmasLights;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day06 : Day2015
    {
        public Day06() : base(6)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var controller1 = new ChristmasLightsController();
            controller1.RunCommands(FileInput, false);
            Console.WriteLine($"Lit lights: {controller1.LitCount}");

            WritePartTitle();
            var controller2 = new ChristmasLightsController();
            controller2.RunCommands(FileInput, true);
            Console.WriteLine($"Total brightness: {controller2.TotalBrightness}");
        }
    }
}