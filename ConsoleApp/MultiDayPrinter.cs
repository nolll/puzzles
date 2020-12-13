using System;
using ConsoleApp.Years;

namespace ConsoleApp
{
    public class MultiDayPrinter
    {
        private readonly int _timeout;

        public MultiDayPrinter(int timeout)
        {
            _timeout = timeout;
        }

        public void PrintHeader()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("| day         | part 1     | part 2     |");
            Console.WriteLine("-----------------------------------------");
        }

        public void PrintDay(DayResult dayResult)
        {
            var day = dayResult.Day.Id.ToString().PadLeft(2, '0');
            var dayAndYear = $"Day {day} {dayResult.Day.Year}";
            var p1 = GetTableResult(dayResult.Result1).PadRight(10, ' ');
            var p1Color = GetColor(dayResult.Result1);
            var p2 = GetTableResult(dayResult.Result2).PadRight(10, ' ');
            var p2Color = GetColor(dayResult.Result2);

            var defaultColor = Console.ForegroundColor;

            Console.Write("| ");
            Console.Write(dayAndYear);
            Console.Write(" | ");
            Console.ForegroundColor = p1Color;
            Console.Write(p1);
            Console.ForegroundColor = defaultColor;
            Console.Write(" | ");
            Console.ForegroundColor = p2Color;
            Console.Write(p2);
            Console.ForegroundColor = defaultColor;
            Console.Write(" | ");
            Console.WriteLine();
        }

        private static ConsoleColor GetColor(PuzzleResult result)
        {
            var status = result.Status;
            if (status == PuzzleResultStatus.Failed || status == PuzzleResultStatus.Missing || status == PuzzleResultStatus.Timeout)
                return ConsoleColor.Red;

            return status == PuzzleResultStatus.Correct
                ? ConsoleColor.Green
                : ConsoleColor.Yellow;
        }

        private string GetTableResult(TimedPuzzleResult result)
        {
            if (result.Status == PuzzleResultStatus.Empty)
                return "";

            if (result.Status == PuzzleResultStatus.Failed)
                return "failed";

            if (result.Status == PuzzleResultStatus.Missing)
                return "missing";

            var timeTaken = result.Status == PuzzleResultStatus.Timeout
                ? TimeSpan.FromSeconds(_timeout)
                : result.TimeTaken;

            var formattedTime = Formatter.FormatTime(timeTaken);

            return result.Status == PuzzleResultStatus.Timeout
                ? $">{formattedTime}"
                : formattedTime;
        }

        public void PrintFooter()
        {
            Console.WriteLine("-----------------------------------------");
        }
    }
}