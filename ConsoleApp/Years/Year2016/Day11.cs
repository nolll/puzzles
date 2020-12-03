using System;
using Core.Radioisotope;

namespace ConsoleApp.Years.Year2016
{
    public class Day11 : Day2016
    {
        public Day11() : base(11)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var simulator1 = new RadioisotopeSimulator(Input1);
            Console.WriteLine($"Required number of steps: {simulator1.StepCount}");

            WritePartTitle();
            var simulator2 = new RadioisotopeSimulator(Input2);
            Console.WriteLine($"Required number of steps: {simulator2.StepCount}");
        }

        private const string Input1 = @"The first floor contains a strontium generator, a strontium-compatible microchip, a plutonium generator, and a plutonium-compatible microchip.
The second floor contains a thulium generator, a ruthenium generator, a ruthenium-compatible microchip, a curium generator, and a curium-compatible microchip.
The third floor contains a thulium-compatible microchip.
The fourth floor contains nothing relevant.";

        private const string Input2 = @"The first floor contains a strontium generator, a strontium-compatible microchip, a plutonium generator, a plutonium-compatible microchip, an elerium generator, an elerium-compatible microchip, a dilithium generator, and a dilithium-compatible microchip.
The second floor contains a thulium generator, a ruthenium generator, a ruthenium-compatible microchip, a curium generator, and a curium-compatible microchip.
The third floor contains a thulium-compatible microchip.
The fourth floor contains nothing relevant.";
    }
}