using System;

namespace Core.Computer
{
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