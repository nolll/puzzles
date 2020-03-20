using System;
using Core.RpgSimulation;

namespace ConsoleApp.Years.Year2015
{
    public class Day21 : Day
    {
        public Day21() : base(21)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var simulator = new RpgSimulator();
            var leastGoldRequiredToWin = simulator.RunWithLeastCost(104, 8, 1);
            Console.WriteLine($"Least amount of gold to win: {leastGoldRequiredToWin}");
        }
    }
}