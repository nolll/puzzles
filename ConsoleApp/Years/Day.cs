using System;
using System.Globalization;
using System.IO;
using System.Text;
using Core.Tools;

namespace ConsoleApp.Years
{
    public abstract class Day
    {
        private const string Divider = "--------------------------------------------------";

        private int _part;
        protected abstract void RunDay();
        protected abstract int Year { get; }
        private readonly Timer _timer;
        public int Id { get; }

        protected Day(int day)
        {
            Id = day;
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

        protected virtual string Input
        {
            get
            {
                var filePath = FilePath;
                if(!File.Exists(filePath))
                    throw new FileNotFoundException("File not found", filePath);

                return File.ReadAllText(filePath, Encoding.UTF8);
            }
        }

        private string FilePath => Path.Combine(
                Directory.GetCurrentDirectory(),
                "Years",
                $"Year{Year}",
                "Days",
                $"Day{PaddedDay}.txt");

        private string PaddedDay => Id.ToString().PadLeft(2, '0');

        protected void WritePartTitle()
        {
            Console.WriteLine();
            Console.WriteLine($"Part {_part}:");
            _part++;
        }

        private void WriteDayTitle()
        {
            Console.WriteLine();
            Console.WriteLine($"Day {Id}:");
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