using System;

namespace Core.Computer
{
    public class AmplifierComputer : IntCodeComputer
    {
        private readonly Func<long> _readInputFunc;
        private readonly Action<long> _writeOutputFunc;

        public AmplifierComputer(string input, Func<long> readInputFunc, Action<long> writeOutputFunc)
            : base(input)
        {
            _readInputFunc = readInputFunc;
            _writeOutputFunc = writeOutputFunc;
        }

        protected override long ReadInput()
        {
            return _readInputFunc();
        }

        protected override void WriteOutput(long output)
        {
            _writeOutputFunc(output);
        }
    }
}