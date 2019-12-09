using System;

namespace Core.Computer
{
    public class ConsoleComputer : IntCodeComputer
    {
        public int Output { get; private set; } = 0;

        public ConsoleComputer(string input) : base(input)
        {
        }

        protected override int ReadInput()
        {
            Console.Write("Enter the ID of the system: ");
            var str = Console.ReadLine() ?? "";
            return int.Parse(str);
        }

        protected override void WriteOutput(int output)
        {
            Output = output;
            Console.WriteLine(output);
        }
    }

    public class BoostTester
    {
        private int _output;

        public Result Run(string program)
        {
            var computer = new AmplifierComputer(program, ReadInput, WriteOutput);
            computer.Start();

            return new Result(_output, computer.Memory);
        }

        public int ReadInput()
        {
            return 0;
        }

        public void WriteOutput(int output)
        {
            _output = output;
        }

        public class Result
        {
            public int Output { get; }
            public string MemoryString { get; }

            public Result(int output, int[] memory)
            {
                MemoryString = string.Join(',', memory);
                Output = output;
            }
        }
    }
}