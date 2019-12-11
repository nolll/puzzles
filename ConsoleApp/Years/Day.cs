using System;
using System.Globalization;

namespace ConsoleApp.Years
{
    public abstract class Day
    {
        private const string Divider = "--------------------------------------------------";

        private readonly int _day;
        private int _part;
        protected abstract void RunDay();
        private readonly Timer _timer;

        protected Day(int day)
        {
            _day = day;
            _timer = new Timer();
            _part = 1;
        }

        public void Run()
        {
            _timer.Start();
            WriteDayTitle();
            RunDay();
            WriteDayEnd();
        }

        protected void WritePartTitle()
        {
            Console.WriteLine();
            Console.WriteLine($"Part {_part}:");
            _part++;
        }

        private void WriteDayTitle()
        {
            Console.WriteLine();
            Console.WriteLine($"Day {_day}:");
            WriteDivider();
        }

        private void WriteDayEnd()
        {
            WriteDivider();
            WriteTimer();
        }

        private void WriteDivider()
        {
            Console.WriteLine(Divider);
        }

        private void WriteTimer()
        {
            var timeTaken = _timer.FromStart;
            var seconds = timeTaken.TotalMilliseconds / 1000;
            var decimalSeconds = Convert.ToDecimal(seconds);
            var roundedSeconds = Math.Round(decimalSeconds, 2);
            var secondsString = roundedSeconds.ToString(CultureInfo.InvariantCulture);
            var timeString = $"{secondsString}s";
            Console.WriteLine(timeString.PadLeft(Divider.Length));
        }
    }
}