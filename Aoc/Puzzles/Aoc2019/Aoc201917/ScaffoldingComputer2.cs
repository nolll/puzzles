using Puzzles.Common.Computers.IntCode;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201917;

public class ScaffoldingComputer2
{
    private readonly IntCodeComputer _computer;
    private long _output;

    private const string MainRoutine = "A,B,A,C,B,C,A,B,A,C";
    private const string FunctionA = "R,6,L,10,R,8,R,8";
    private const string FunctionB = "R,12,L,8,L,10";
    private const string FunctionC = "R,12,L,10,R,6,L,10";

    private readonly IList<int> _inputSequence;

    public ScaffoldingComputer2(string program)
    {
        _computer = new IntCodeComputer($"2{program[1..]}", ReadInput, WriteOutput);
        _inputSequence = BuildInputSequence();
    }

    private IList<int> BuildInputSequence()
    {
        var inputSequence = new List<int>();
        inputSequence.AddRange(MainRoutine.ToCharArray().Select(o => (int)o));
        inputSequence.Add(10);
        inputSequence.AddRange(FunctionA.ToCharArray().Select(o => (int)o));
        inputSequence.Add(10);
        inputSequence.AddRange(FunctionB.ToCharArray().Select(o => (int)o));
        inputSequence.Add(10);
        inputSequence.AddRange(FunctionC.ToCharArray().Select(o => (int)o));
        inputSequence.Add(10);
        inputSequence.Add('n');
        inputSequence.Add(10);

        return inputSequence;
    }

    public long Run()
    {
        _computer.Start();
        return _output;
    }

    private long ReadInput()
    {
        if (_inputSequence.Any())
        {
            var val = _inputSequence.First();
            _inputSequence.RemoveAt(0);
            return val;
        }

        return 0;
    }

    private bool WriteOutput(long output)
    {
        _output = output;
        return true;
    }
}