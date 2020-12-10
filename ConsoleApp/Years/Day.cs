using System;
using System.IO;
using System.Text;
using Core.Tools;

namespace ConsoleApp.Years
{
    public abstract class Day
    {
        private int _part;
        protected abstract void RunDay();
        public abstract int Year { get; }
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

        protected string FileInput
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
                "Inputs",
                $"{PaddedDay}.txt");

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
            Console.WriteLine($"Day {Id} {Year}:");
            Printer.PrintDivider();
        }

        private void WriteDayEnd()
        {
            Printer.PrintDivider();
            Printer.PrintTime(_timer);
        }

    }
}