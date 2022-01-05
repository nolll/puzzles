namespace App.Common.Computers.Operation;

public class GtriOperation : Operation
{
    public GtriOperation() : base("gtri")
    {
    }

    public override long[] Execute(long[] registers, long a, long b, long c)
    {
        registers[c] = registers[a] > b ? 1 : 0;
        return registers;
    }

    public override string GetDescription(long[] registers, long a, long b, long c)
    {
        return $"Greater-than register/immediate. Sets register {c} to 1 if register {a} ({registers[a]}) is greater than value {b}. Otherwise, register {c} is set to 0.";
    }

    public override string GetShortDescription(long[] registers, long a, long b, long c)
    {
        return $"reg[{c}] = {registers[a]} > {b} ? 1 : 0.";
    }
}