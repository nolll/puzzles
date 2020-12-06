using System;
using Core.RepetitionCode;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day06 : Day2016
    {
        public Day06() : base(6)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var reader = new RepetitionCodeReader();
            var messageMostCommon = reader.ReadMostCommon(FileInput);
            Console.WriteLine($"Message most common: {messageMostCommon}");

            WritePartTitle();
            var messageLeastCommon = reader.ReadLeastCommon(FileInput);
            Console.WriteLine($"Message least common: {messageLeastCommon}");
        }
    }
}