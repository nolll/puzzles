using System;
using Core.Platform;

namespace ConsoleApp.Printing
{
    public class MultiDayPrinter : DayPrinter, IMultiDayPrinter
    {
        private readonly int _timeout;
        private const int CommentLength = 24;

        public MultiDayPrinter(int? timeout = null)
        {
            _timeout = timeout ?? 0;
        }

        public void PrintHeader()
        {
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("| day         | part 1     | part 2     | comment                  |");
            Console.WriteLine("--------------------------------------------------------------------");
        }

        public void PrintDay(DayResult dayResult)
        {
            var day = dayResult.Day.Id.ToString().PadLeft(2, '0');
            var dayAndYear = $"Day {day} {dayResult.Day.Year}";
            var p1 = GetTableResult(dayResult.Result1).PadRight(10, ' ');
            var p1Color = GetColor(dayResult.Result1);
            var p2 = GetTableResult(dayResult.Result2).PadRight(10, ' ');
            var p2Color = GetColor(dayResult.Result2);
            var comment = dayResult.Comment.Length > (CommentLength - 3)
                ? dayResult.Comment.Substring(0, CommentLength - 3) + "..."
                : dayResult.Comment;
            var paddedComment = comment.PadRight(CommentLength, ' ');

            Console.Write("| ");
            Console.Write(dayAndYear);
            Console.Write(" | ");
            SetColor(p1Color);
            Console.Write(p1);
            ResetColor();
            Console.Write(" | ");
            SetColor(p2Color);
            Console.Write(p2);
            ResetColor();
            Console.Write(" | ");
            SetColor(ConsoleColor.Yellow);
            Console.Write(paddedComment);
            ResetColor();
            Console.Write(" |"); 
            Console.WriteLine();
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
            Console.WriteLine("--------------------------------------------------------------------");
        }
    }
}