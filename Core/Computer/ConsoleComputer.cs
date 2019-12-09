using System;
using System.Collections.Generic;

namespace Core.Computer
{
    public class ConsoleComputer : IntCodeComputer
    {
        public long Output { get; private set; }

        public ConsoleComputer(string input) : base(input)
        {
        }

        protected override long ReadInput()
        {
            Console.Write("Enter the ID of the system: ");
            var str = Console.ReadLine() ?? "";
            return int.Parse(str);
        }

        protected override void WriteOutput(long output)
        {
            Output = output;
            Console.WriteLine(output);
        }
    }

    public class BoostTester
    {
        private long _output;

        public Result Run(string program)
        {
            var computer = new AmplifierComputer(program, ReadInput, WriteOutput);
            computer.Start();

            return new Result(_output, computer.Memory);
        }

        public long ReadInput()
        {
            return 0;
        }

        public void WriteOutput(long output)
        {
            _output = output;
        }

        public class Result
        {
            public long Output { get; }
            public string MemoryString { get; }

            public Result(long output, IList<long> memory)
            {
                MemoryString = string.Join(',', memory);
                Output = output;
            }
        }
    }
}