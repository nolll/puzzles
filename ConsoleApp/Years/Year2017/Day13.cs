﻿using System;
using Core.Firewall;

namespace ConsoleApp.Years.Year2017
{
    public class Day13 : Day2017
    {
        public Day13() : base(13)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var scanner1 = new PacketScanner(Input);
            var severity = scanner1.GetSeverity();
            Console.WriteLine($"Severity: {severity}");

            WritePartTitle();
            var scanner2 = new PacketScanner(Input);
            var delay = scanner2.DelayUntilPass();
            Console.WriteLine($"Delay: {delay}");
        }

        protected override string Input => @"0: 3
1: 2
2: 4
4: 6
6: 5
8: 6
10: 6
12: 4
14: 8
16: 8
18: 9
20: 8
22: 6
24: 14
26: 12
28: 10
30: 12
32: 8
34: 10
36: 8
38: 8
40: 12
42: 12
44: 12
46: 12
48: 14
52: 14
54: 12
56: 12
58: 12
60: 12
62: 14
64: 14
66: 14
68: 14
70: 14
72: 14
80: 18
82: 14
84: 20
86: 14
90: 17
96: 20
98: 24";
    }
}