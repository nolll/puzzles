using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleApp.Years;
using Core.Tools;

namespace ConsoleApp
{
    public class PuzzleRunner
    {
        private readonly bool _throwExceptions;
        private readonly int? _timeout;

        public PuzzleRunner(bool throwExceptions = false, int? timeout = null)
        {
            _throwExceptions = throwExceptions;
            _timeout = timeout;
        }

        public void Run(IList<Day> days)
        {
            var printer = new MultiDayPrinter(_timeout ?? 0);
            printer.PrintHeader();
            foreach (var day in days)
            {
                var result = RunDay(day);
                printer.PrintDay(result);
            }
            printer.PrintFooter();
        }

        public void Run(Day day)
        {
            var result = RunDay(day);
            var printer = new SingleDayPrinter();
            printer.PrintDay(result);
        }

        private DayResult RunDay(Day day)
        {
            var p1 = RunPuzzleWithTimer(day.RunPart1);
            var p2 = RunPuzzleWithTimer(day.RunPart2);

            return new DayResult(day, p1, p2, day.Comment);
        }

        private TimedPuzzleResult RunPuzzleWithTimer(Func<PuzzleResult> func)
        {
            var timer = new Timer();
            var result = RunPuzzle(func);
            return new TimedPuzzleResult(result, timer.FromStart);
        }

        private PuzzleResult RunPuzzle(Func<PuzzleResult> func)
        {
            PuzzleResult result = null;
            try
            {
                if (_timeout != null)
                {
                    var task1 = Task.Run(() => result = func());
                    if (!task1.Wait(TimeSpan.FromSeconds(_timeout.Value)))
                        return new TimeoutPuzzleResult($"Puzzle failed to finish within {_timeout.Value} seconds");
                }
                else
                {
                    result = func();
                }

                return result ?? new MissingPuzzleResult("Puzzle returned null");
            }
            catch (Exception)
            {
                if (_throwExceptions)
                    throw;
                return new FailedPuzzleResult("Puzzle failed");
            }
        }
    }
}