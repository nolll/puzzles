using System;
using Core.Tools;
using Core.WizardRpgSimulation;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day22 : Day2015
    {
        public Day22() : base(22)
        {
        }

        protected override void RunDay()
        {
            var p = GetParams();

            WritePartTitle();
            var simulator1 = new WizardRpgSimulator(WizardRpgGameMode.Easy);
            var leastManaRequiredToWinEasy = simulator1.WinWithLowestCost(p.HitPoints, p.Damage);
            Console.WriteLine($"Least amount of mana to win in easy mode: {leastManaRequiredToWinEasy}");

            WritePartTitle();
            var simulator2 = new WizardRpgSimulator(WizardRpgGameMode.Hard);
            var leastManaRequiredToWinHard = simulator2.WinWithLowestCost(p.HitPoints, p.Damage);
            Console.WriteLine($"Least amount of mana to win in hard mode: {leastManaRequiredToWinHard}");
        }

        private Params GetParams()
        {
            var rows = PuzzleInputReader.ReadLines(FileInput);

            return new Params
            {
                HitPoints = GetIntFromRow(rows[0]),
                Damage = GetIntFromRow(rows[1])
            };
        }

        private static int GetIntFromRow(string s)
        {
            return int.Parse(s.Split(':')[1].Trim());
        }

        private class Params
        {
            public int HitPoints { get; set; }
            public int Damage { get; set; }
        }
    }
}