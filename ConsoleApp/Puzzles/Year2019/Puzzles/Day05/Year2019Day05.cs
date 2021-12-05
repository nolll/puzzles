using Core.Computer;

namespace ConsoleApp.Puzzles.Year2019.Puzzles.Day05
{
    public class Year2019Day05 : Year2019Day
    {
        private long _output;

        public override int Day => 5;

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