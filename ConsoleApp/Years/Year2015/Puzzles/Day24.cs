using System;
using Core.BalancedPresents;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day24 : Day2015
    {
        public Day24() : base(24)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var balancer1 = new PresentBalancer(FileInput, 3);
            return new PuzzleResult($"Quantum entanglement of the first group of three: {balancer1.QuantumEntanglementOfFirstGroup}");
        }

        public override PuzzleResult RunPart2()
        {
            var balancer2 = new PresentBalancer(FileInput, 4);
            return new PuzzleResult($"Quantum entanglement of the first group of four: {balancer2.QuantumEntanglementOfFirstGroup}");
        }
    }
}