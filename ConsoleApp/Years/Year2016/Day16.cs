using System;
using Core.DragonChecksum;

namespace ConsoleApp.Years.Year2016
{
    public class Day16 : Day2016
    {
        public Day16() : base(16)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var dragonCurve = new DragonCurve();
            var checksum1 = dragonCurve.Run(Input, 272);
            Console.WriteLine($"Checksum 1: {checksum1}");

            WritePartTitle();
            var checksum2 = dragonCurve.Run(Input, 35651584);
            Console.WriteLine($"Checksum 2: {checksum2}");
        }

        protected override string Input => "01000100010010111";
    }
}