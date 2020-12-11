using System;
using Core.InfiniteElvesAndHouses;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day20 : Day2015
    {
        public Day20() : base(20)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var presentDelivery1 = new PresentDelivery();
            var house1 = presentDelivery1.Deliver1(Input);
            return new PuzzleResult($"First house to get {FileInput} presents: {house1}");
        }

        public override PuzzleResult RunPart2()
        {
            var presentDelivery2 = new PresentDelivery();
            var house2 = presentDelivery2.Deliver2(Input);
            return new PuzzleResult($"First house to get {FileInput} presents: {house2}");
        }

        private const int Input = 34_000_000;
    }
}