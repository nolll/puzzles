namespace Aoc.Common.Computers.Operation;

public class AddrOperation : Operation
{
    public AddrOperation() : base("addr")
    {
    }

    public override void Execute(long[] registers, long a, long b, long c)
    {
        registers[c] = registers[a] + registers[b];
    }

    public override string GetDescription(long[] registers, long a, long b, long c)
    {
        return $"Add register. Stores into register {c} the result of adding register {a} ({registers[a]}) and register {b} ({registers[b]}).";
    }

    public override string GetShortDescription(long[] registers, long a, long b, long c)
    {
        return $"reg[{c}] = {registers[a]} + {registers[b]}.";
    }
}