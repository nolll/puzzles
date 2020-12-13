using System;
using ConsoleApp.Years;

namespace ConsoleApp
{
    public abstract class DayPrinter
    {
        private readonly ConsoleColor _defaultColor;

        protected DayPrinter()
        {
            _defaultColor = Console.ForegroundColor;
        }

        protected void ResetColor()
        {
            Console.ForegroundColor = _defaultColor;
        }

        protected void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        protected static ConsoleColor GetColor(PuzzleResult result)
        {
            var status = result.Status;
            if (status == PuzzleResultStatus.Failed || status == PuzzleResultStatus.Missing || status == PuzzleResultStatus.Timeout)
                return ConsoleColor.Red;

            return status == PuzzleResultStatus.Correct
                ? ConsoleColor.Green
                : ConsoleColor.Yellow;
        }
    }
}