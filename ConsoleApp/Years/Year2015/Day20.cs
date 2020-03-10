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
            var presentDelivery1 = new PresentDelivery();
            var house1 = presentDelivery1.Deliver1(Input);
            Console.WriteLine($"First house to get {Input} presents: {house1}");

            WritePartTitle();
            var presentDelivery2 = new PresentDelivery();
            var house2 = presentDelivery2.Deliver2(Input);
            Console.WriteLine($"First house to get {Input} presents: {house2}");
        }

        private const int Input = 34_000_000;
    }
}