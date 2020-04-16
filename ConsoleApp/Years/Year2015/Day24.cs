using System;
using Core.BalancedPresents;

namespace ConsoleApp.Years.Year2015
{
    public class Day24 : Day
    {
        public Day24() : base(24)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var balancer = new PresentBalancer(Input);
            Console.WriteLine($"Quantum entanglement of the first group: {balancer.QuantumEntanglementOfFirstGroup}");

        }

        private const string Input = @"
1
3
5
11
13
17
19
23
29
31
41
43
47
53
59
61
67
71
73
79
83
89
97
101
103
107
109
113";
    }
}