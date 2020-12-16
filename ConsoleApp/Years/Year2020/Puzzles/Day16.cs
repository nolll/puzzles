using Core.TicketValidation;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day16 : Day2020
    {
        public Day16() : base(16)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var validator = new TicketValidator();
            var result = validator.GetErrorRate(FileInput);
            return new PuzzleResult(result, 23_122);
        }

        public override PuzzleResult RunPart2()
        {
            var validator = new TicketValidator();
            var result = validator.CalculateAnswer(FileInput);
            return new PuzzleResult(result, 362_974_212_989);
        }
    }
}