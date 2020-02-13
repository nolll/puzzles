using System;
using Core.DragonChecksum;

namespace ConsoleApp.Years.Year2016
{
    public class Day16 : Day
    {
        public Day16() : base(16)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var dragonCurve = new DragonCurve();
            var checksum = dragonCurve.Run(Input, 272);
            Console.WriteLine($"Checksum: {checksum}");
        }

        private const string Input = "01000100010010111";
    }
}