using System;
using Core.WizardRpgSimulation;

namespace ConsoleApp.Years.Year2015
{
    public class Day22 : Day2015
    {
        public Day22() : base(22)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var simulator1 = new WizardRpgSimulator(WizardRpgGameMode.Easy);
            var leastManaRequiredToWinEasy = simulator1.WinWithLowestCost(71, 10);
            Console.WriteLine($"Least amount of mana to win in easy mode: {leastManaRequiredToWinEasy}");

            WritePartTitle();
            var simulator2 = new WizardRpgSimulator(WizardRpgGameMode.Hard);
            var leastManaRequiredToWinHard = simulator2.WinWithLowestCost(71, 10);
            Console.WriteLine($"Least amount of mana to win in hard mode: {leastManaRequiredToWinHard}");
        }
    }
}