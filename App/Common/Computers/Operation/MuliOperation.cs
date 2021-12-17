namespace App.Common.Computers.Operation;

public class MuliOperation : Operation
{
    public MuliOperation() : base("muli")
    {
    }

    public override long[] Execute(long[] registers, long a, long b, long c)
    {
        registers[c] = registers[a] * b;
        return registers;
    }

    public override string GetDescription(long[] registers, long a, long b, long c)
    {
        return $"Multiply immediate. Stores into register {c} the result of multiplying register {a} ({registers[a]}) and value {b}.";
    }

    public override string GetShortDescription(long[] registers, long a, long b, long c)
    {
        return $"reg[{c}] = {registers[a]} * {b}.";
    }
}