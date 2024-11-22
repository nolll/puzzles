namespace Pzl.Tools.Computers.Operation;

public class GtirOperation : Operation
{
    public GtirOperation() : base("gtir")
    {
    }

    public override void Execute(long[] registers, long a, long b, long c)
    {
        registers[c] = a > registers[b] ? 1 : 0;
    }

    public override string GetDescription(long[] registers, long a, long b, long c)
    {
        return $"Greater-than immediate/register. Sets register {c} to 1 if value {a} is greater than register {b} ({registers[b]}). Otherwise, register {c} is set to 0.";
    }

    public override string GetShortDescription(long[] registers, long a, long b, long c)
    {
        return $"reg[{c}] = {a} > {registers[b]} ? 1 : 0.";
    }
}