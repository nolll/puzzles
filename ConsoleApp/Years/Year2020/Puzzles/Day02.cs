using System;
using System.Linq;
using Core.PasswordPolicy;
using Core.Tools;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day02 : Day2020
    {
        public Day02() : base(2)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var validator = new PasswordPolicyValidator();
            var policies = PuzzleInputReader.ReadLines(LegacyInput);
            var count1 = policies.Count(validator.IsValidAccordingToRuleOne);
            Console.WriteLine($"Number of valid passwords with rule 1: {count1}");

            WritePartTitle();
            var count2 = policies.Count(validator.IsValidAccordingToRuleTwo);
            Console.WriteLine($"Number of valid passwords with rule 2: {count2}");
        }
    }
}