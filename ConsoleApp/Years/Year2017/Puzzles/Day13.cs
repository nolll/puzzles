using System;
using Core.Firewall;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day13 : Day2017
    {
        public Day13() : base(13)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var scanner1 = new PacketScanner(FileInput);
            var severity = scanner1.GetSeverity();
            Console.WriteLine($"Severity: {severity}");

            WritePartTitle();
            var scanner2 = new PacketScanner(FileInput);
            var delay = scanner2.DelayUntilPass();
            Console.WriteLine($"Delay: {delay}");
        }
    }
}