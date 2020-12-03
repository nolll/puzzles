using System;
using Core.BalancedPresents;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day24 : Day2015
    {
        public Day24() : base(24)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var balancer1 = new PresentBalancer(FileInput, 3);
            Console.WriteLine($"Quantum entanglement of the first group of three: {balancer1.QuantumEntanglementOfFirstGroup}");

            WritePartTitle();
            var balancer2 = new PresentBalancer(FileInput, 4);
            Console.WriteLine($"Quantum entanglement of the first group of four: {balancer2.QuantumEntanglementOfFirstGroup}");
        }
    }
}