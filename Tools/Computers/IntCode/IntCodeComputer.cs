namespace Pzl.Tools.Computers.IntCode;

public class IntCodeComputer(IList<long> memory, Func<long>? readInput = null, Func<long, bool>? writeOutput = null)
{
    public Func<long>? ReadInput { get; set; } = readInput;
    public Func<long, bool>? WriteOutput { get; set; } = writeOutput;
    private IntCodeProcess? _process;

    public long Result => _process?.Result ?? 0;

    public IntCodeComputer(string program, Func<long>? readInput = null, Func<long, bool>? writeOutput = null)
        : this(MemoryParser.Parse(program), readInput, writeOutput)
    {
    }

    public void Start(bool haltAfterInput = false, int? noun = null, int? verb = null)
    {
        if (ReadInput == null)
            throw new InvalidOperationException("Read function is null");

        if (WriteOutput == null)
            throw new InvalidOperationException("Write function is null");

        var memory1 = CopyMemory(memory);
        if (noun != null) memory1[1] = noun.Value;
        if (verb != null) memory1[2] = verb.Value;
        _process = new IntCodeProcess(memory1, haltAfterInput, ReadInput, WriteOutput);
        _process.Run();
    }

    public void SetMemory(int address, int value) => memory[address] = value;
    public void Resume() => _process?.Run();
    public void Stop() => _process?.Stop();
    private static IList<long> CopyMemory(IEnumerable<long> memory) => memory.ToList();

    public IntCodeComputer Clone() => new(_process?.Memory ?? new List<long>(), ReadInput, WriteOutput);
}