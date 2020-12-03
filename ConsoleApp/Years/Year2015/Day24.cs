using System;
using Core.BalancedPresents;

namespace ConsoleApp.Years.Year2015
{
    public class Day24 : Day2015
    {
        public Day24() : base(24)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var balancer1 = new PresentBalancer(Input, 3);
            Console.WriteLine($"Quantum entanglement of the first group of three: {balancer1.QuantumEntanglementOfFirstGroup}");

            WritePartTitle();
            var balancer2 = new PresentBalancer(Input, 4);
            Console.WriteLine($"Quantum entanglement of the first group of four: {balancer2.QuantumEntanglementOfFirstGroup}");
        }

        protected override string Input => @"
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