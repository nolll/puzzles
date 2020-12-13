using System;
using Core.Spreadsheets;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day02 : Day2017
    {
        public Day02() : base(2)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var spreadsheet = new Spreadsheet(FileInput);
            return new PuzzleResult(spreadsheet.ChecksumMaxMin, 42_378);
        }

        public override PuzzleResult RunPart2()
        {
            var spreadsheet = new Spreadsheet(FileInput);
            return new PuzzleResult(spreadsheet.ChecksumDivision, 246);
        }
    }
}