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
            var presentDelivery = new PresentDelivery();
            var house = presentDelivery.Deliver1(Input);
            return new PuzzleResult(house, 786_240);
        }

        public override PuzzleResult RunPart2()
        {
            var presentDelivery = new PresentDelivery();
            var house = presentDelivery.Deliver2(Input);
            return new PuzzleResult(house, 831_600);
        }

        private const int Input = 34_000_000;
    }
}