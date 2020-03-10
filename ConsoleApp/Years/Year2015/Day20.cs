using System;
using Core.InfiniteElvesAndHouses;

namespace ConsoleApp.Years.Year2015
{
    public class Day20 : Day
    {
        public Day20() : base(20)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var presentDelivery = new PresentDelivery();
            var house = presentDelivery.Deliver(Input);
            Console.WriteLine($"First house to get {Input} presents: {house}");
        }

        private const int Input = 34_000_000;
    }
}