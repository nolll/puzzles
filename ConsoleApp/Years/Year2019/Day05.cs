using System;
using Core.Computer;
using Data.Inputs;

namespace ConsoleApp.Years.Year2019
{
    public class Day05 : Day
    {
        private long _output;

        public Day05() : base(5)
        {
            _output = 0;
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var ci1 = new ComputerInterface(InputData.ComputerProgramDay5, ReadInputPart1, WriteOutput);
            ci1.Start();

            Console.WriteLine($"Diagnostic code for ID 1: {_output}");

            WritePartTitle();
            var ci2 = new ComputerInterface(InputData.ComputerProgramDay5, ReadInputPart2, WriteOutput);
            ci2.Start();

            Console.WriteLine($"Diagnostic code for ID 5: {_output}");
        }

        private long ReadInputPart1() => 1;
        private long ReadInputPart2() => 5;

        private void WriteOutput(long output)
        {
            _output = output;
        }
    }
}