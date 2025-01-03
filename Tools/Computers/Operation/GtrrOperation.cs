namespace Pzl.Tools.Computers.Operation;

public class GtrrOperation : Operation
{
    public GtrrOperation() : base("gtrr")
    {
    }

    public override void Execute(long[] registers, long a, long b, long c)
    {
        registers[c] = registers[a] > registers[b] ? 1 : 0;
    }

    public override string GetDescription(long[] registers, long a, long b, long c)
    {
        return $"Greater-than register/register. Sets register {c} to 1 if register {a} ({registers[a]}) is greater than register {b} ({registers[b]}). Otherwise, register {c} is set to 0.";
    }

    public override string GetShortDescription(long[] registers, long a, long b, long c)
    {
        return $"reg[{c}] = {registers[a]} > {registers[b]} ? 1 : 0.";
    }
}