using System;
using Core.Computer;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day05 : Day2019
    {
        private long _output;

        public Day05() : base(5)
        {
            _output = 0;
        }

        public override PuzzleResult RunPart1()
        {
            var ci1 = new ComputerInterface(FileInput, ReadInputPart1, WriteOutput);
            ci1.Start();

            return new PuzzleResult(_output, 5_346_030);
        }

        public override PuzzleResult RunPart2()
        {
            var ci2 = new ComputerInterface(FileInput, ReadInputPart2, WriteOutput);
            ci2.Start();

            return new PuzzleResult(_output, 513_116);
        }

        private long ReadInputPart1() => 1;
        private long ReadInputPart2() => 5;

        private void WriteOutput(long output)
        {
            _output = output;
        }
    }
}