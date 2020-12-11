using System;
using Core.RepetitionCode;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day06 : Day2016
    {
        public Day06() : base(6)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var reader = new RepetitionCodeReader();
            var messageMostCommon = reader.ReadMostCommon(FileInput);
            return new PuzzleResult($"Message most common: {messageMostCommon}");
        }

        public override PuzzleResult RunPart2()
        {
            var reader = new RepetitionCodeReader();
            var messageLeastCommon = reader.ReadLeastCommon(FileInput);
            return new PuzzleResult($"Message least common: {messageLeastCommon}");
        }
    }
}