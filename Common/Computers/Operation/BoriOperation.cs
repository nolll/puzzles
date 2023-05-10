namespace Aoc.Common.Computers.Operation;

public class BoriOperation : Operation
{
    public BoriOperation() : base("bori")
    {
    }

    public override void Execute(long[] registers, long a, long b, long c)
    {
        registers[c] = registers[a] | b;
    }

    public override string GetDescription(long[] registers, long a, long b, long c)
    {
        return $"Bitwise OR immediate. Stores into register {c} the result of the bitwise OR of register {a} ({registers[a]}) and value {b}.";
    }

    public override string GetShortDescription(long[] registers, long a, long b, long c)
    {
        return $"reg[{c}] = {registers[a]} | {b}.";
    }
}