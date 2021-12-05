using System.Linq;
using Core.Tools;

namespace ConsoleApp.Puzzles.Year2020.Day02
{
    public class Year2020Day02 : Year2020Day
    {
        public override int Day => 2;

        public override PuzzleResult RunPart1()
        {
            var validator = new PasswordPolicyValidator();
            var policies = PuzzleInputReader.ReadLines(FileInput);
            var count = policies.Count(validator.IsValidAccordingToRuleOne);
            return new PuzzleResult(count, 556);
        }

        public override PuzzleResult RunPart2()
        {
            var validator = new PasswordPolicyValidator();
            var policies = PuzzleInputReader.ReadLines(FileInput);
            var count = policies.Count(validator.IsValidAccordingToRuleTwo);
            return new PuzzleResult(count, 605);
        }
    }
}