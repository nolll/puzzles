using System;

namespace ConsoleApp.Years
{
    public abstract class Day
    {
        private readonly int _day;
        private int _part;
        protected abstract void RunDay();

        protected Day(int day)
        {
            _day = day;
            _part = 1;
        }

        public void Run()
        {
            WriteDayTitle();
            RunDay();
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
            Console.WriteLine("-------------------------");
        }
    }
}