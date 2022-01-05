using System.Collections.Generic;

namespace Core.Common.Computers.IntCode;

public class BoostRunner
{
    private readonly string _program;
    private readonly int _mode;
    private long _lastOutput;
    private IList<long> _outputs;

    public BoostRunner(string program, int mode)
    {
        _program = program;
        _mode = mode;
    }

    public Result Run()
    {
        _outputs = new List<long>();

        var computer = new ComputerInterface(_program, ReadInput, WriteOutput);
        computer.Start();

        return new Result(_lastOutput, _outputs);
    }

    public long ReadInput()
    {
        return _mode;
    }

    public void WriteOutput(long output)
    {
        _lastOutput = output;
        _outputs.Add(output);
    }

    public class Result
    {
        public long LastOutput { get; }
        public IList<long> AllOutputs { get; }

        public Result(long lastOutput, IList<long> allOutputs)
        {
            AllOutputs = allOutputs;
            LastOutput = lastOutput;
        }
    }
}