namespace Pzl.Tools.Computers.Operation;

public abstract class Operation(string name, OperationType type)
{
    public string Name { get; } = name;
    public OperationType Type { get; } = type;
    public abstract void Execute(long[] registers, long a, long b, long c);

    public abstract string GetDescription(long[] registers, long a, long b, long c);
    public abstract string GetShortDescription(long[] registers, long a, long b, long c);
}