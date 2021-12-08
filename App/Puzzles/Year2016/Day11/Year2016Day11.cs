using App.Platform;

namespace App.Puzzles.Year2016.Day11
{
    public class Year2016Day11 : Year2016Day
    {
        public override string Comment => "Floor permutations";
        public override bool IsSlow => true;

        public override int Day => 11;

        public override PuzzleResult RunPart1()
        {
            var simulator = new RadioisotopeSimulator(Input1);
            return new PuzzleResult(simulator.StepCount, 37);
        }

        public override PuzzleResult RunPart2()
        {
            var simulator = new RadioisotopeSimulator(Input2);
            return new PuzzleResult(simulator.StepCount, 61);
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