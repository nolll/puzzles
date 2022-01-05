using System;

namespace Core.Common.Computers.IntCode;

public class ComputerInterface : IntCodeComputer
{
    private readonly Func<long> _readInputFunc;
    private readonly Action<long> _writeOutputFunc;

    public ComputerInterface(string input, Func<long> readInputFunc, Action<long> writeOutputFunc)
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