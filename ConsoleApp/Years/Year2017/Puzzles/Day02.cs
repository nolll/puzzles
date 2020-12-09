using System;
using Core.Spreadsheets;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day02 : Day2017
    {
        public Day02() : base(2)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var spreadsheet = new Spreadsheet(FileInput);
            Console.WriteLine($"Spreadsheet max/min checksum: {spreadsheet.ChecksumMaxMin}");

            WritePartTitle();
            Console.WriteLine($"Spreadsheet division checksum: {spreadsheet.ChecksumDivision}");
        }
    }
}