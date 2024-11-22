namespace Pzl.Tools.Computers.IntCode;

public class IntCodeComputer
{
    private readonly Func<long> _readInput;
    private readonly Func<long, bool> _writeOutput;
    private readonly IList<long> _memory;
    private IntCodeProcess? _process;

    public long Result => _process?.Result ?? 0;

    public IntCodeComputer(IList<long> memory, Func<long> readInput, Func<long, bool> writeOutput)
    {
        _readInput = readInput;
        _writeOutput = writeOutput;
        _memory = memory;
    }

    public IntCodeComputer(string program, Func<long> readInput, Func<long, bool> writeOutput)
        : this(MemoryParser.Parse(program), readInput, writeOutput)
    {
    }

    public void Start(bool haltAfterInput = false, int? noun = null, int? verb = null)
    {
        var memory = CopyMemory(_memory);
        if (noun != null) memory[1] = noun.Value;
        if (verb != null) memory[2] = verb.Value;
        _process = new IntCodeProcess(memory, haltAfterInput, _readInput, _writeOutput);
        _process.Run();
    }

    public void SetMemory(int address, int value) => _memory[address] = value;
    public void Resume() => _process?.Run();
    public void Stop() => _process?.Stop();
    private static IList<long> CopyMemory(IEnumerable<long> memory) => memory.ToList();

    public IntCodeComputer Clone()
    {
        return new IntCodeComputer(_process?.Memory ?? new List<long>(), _readInput, _writeOutput);
    }
}