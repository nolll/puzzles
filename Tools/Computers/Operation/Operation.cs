namespace Pzl.Tools.Computers.Operation;

public abstract class Operation
{
    public string Name { get; }
    public abstract void Execute(long[] registers, long a, long b, long c);

    protected Operation(string name)
    {
        Name = name;
    }

    public abstract string GetDescription(long[] registers, long a, long b, long c);
    public abstract string GetShortDescription(long[] registers, long a, long b, long c);
}