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
    }
}