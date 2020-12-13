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
            return new PuzzleResult(balancer1.QuantumEntanglementOfFirstGroup, 11_266_889_531);
        }

        public override PuzzleResult RunPart2()
        {
            var balancer2 = new PresentBalancer(FileInput, 4);
            return new PuzzleResult(balancer2.QuantumEntanglementOfFirstGroup, 77_387_711);
        }
    }
}