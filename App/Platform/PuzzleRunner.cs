using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Common.Timing;

namespace App.Platform
{
    public class PuzzleRunner
    {
        private readonly ISingleDayPrinter _singleDayPrinter;
        private readonly IMultiDayPrinter _multiDayPrinter;
        private readonly bool _throwExceptions;
        private readonly int? _timeout;

        public PuzzleRunner(ISingleDayPrinter singleDayPrinter, IMultiDayPrinter multiDayPrinter, bool throwExceptions = false, int? timeout = null)
        {
            _singleDayPrinter = singleDayPrinter;
            _multiDayPrinter = multiDayPrinter;
            _throwExceptions = throwExceptions;
            _timeout = timeout;
        }

        public void Run(IList<PuzzleDay> days)
        {
            _multiDayPrinter.PrintHeader();
            foreach (var day in days)
            {
                var result = RunDay(day);
                _multiDayPrinter.PrintDay(result);
            }
            _multiDayPrinter.PrintFooter();
        }

        public void Run(PuzzleDay day)
        {
            var result = RunDay(day);
            _singleDayPrinter.PrintDay(result);
        }

        private DayResult RunDay(PuzzleDay day)
        {
            var p1 = RunPuzzleWithTimer(day.RunPart1, day.IsSlow);
            var p2 = RunPuzzleWithTimer(day.RunPart2, day.IsSlow);

            return new DayResult(day, p1, p2, day.Comment);
        }

        private TimedPuzzleResult RunPuzzleWithTimer(Func<PuzzleResult> func, bool isSlow)
        {
            var timer = new Timer();
            var result = RunPuzzle(func, isSlow);
            return new TimedPuzzleResult(result, timer.FromStart);
        }

        private PuzzleResult RunPuzzle(Func<PuzzleResult> func, bool isSlow)
        {
            PuzzleResult result = null;
            try
            {
                if (isSlow && _timeout != null)
                {
                    var task = Task.Run(() => result = func());
                    if (!task.Wait(TimeSpan.FromSeconds(_timeout.Value)))
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