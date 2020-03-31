using System;
using Core.WizardRpgSimulation;

namespace ConsoleApp.Years.Year2015
{
    public class Day22 : Day
    {
        public Day22() : base(22)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var simulator = new WizardRpgSimulator();
            var leastManaRequiredToWin = simulator.WinWithLowestCost(71, 10);
            Console.WriteLine($"Least amount of mana to win: {leastManaRequiredToWin}");
        }
    }
}