using System;

namespace Core.Computer
{
    public class ConsoleComputer : IntCodeComputer
    {
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
            Console.WriteLine(output);
        }
    }

    public class AmplifierComputer : IntCodeComputer
    {
        private readonly Func<int> _readInputFunc;
        private readonly Action<int> _writeOutputFunc;

        public AmplifierComputer(string input, Func<int> readInputFunc, Action<int> writeOutputFunc)
            : base(input)
        {
            _readInputFunc = readInputFunc;
            _writeOutputFunc = writeOutputFunc;
        }

        protected override int ReadInput()
        {
            return _readInputFunc();
        }

        protected override void WriteOutput(int output)
        {
            _writeOutputFunc(output);
        }
    }
}