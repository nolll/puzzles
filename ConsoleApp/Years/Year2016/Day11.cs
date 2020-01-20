using System;
using Core.Radioisotope;

namespace ConsoleApp.Years.Year2016
{
    public class Day11 : Day
    {
        public Day11() : base(11)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var simulator = new RadioisotopeSimulator(Input);
            Console.WriteLine($"Required number of steps: {simulator.StepCount}");
        }

        private const string Input = @"The first floor contains a strontium generator, a strontium-compatible microchip, a plutonium generator, and a plutonium-compatible microchip.
The second floor contains a thulium generator, a ruthenium generator, a ruthenium-compatible microchip, a curium generator, and a curium-compatible microchip.
The third floor contains a thulium-compatible microchip.
The fourth floor contains nothing relevant.";
    }
}