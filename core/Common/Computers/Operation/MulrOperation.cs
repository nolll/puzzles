namespace Core.Common.Computers.Operation;

public class MulrOperation : Operation
{
    public MulrOperation() : base("mulr")
    {
    }

    public override long[] Execute(long[] registers, long a, long b, long c)
    {
        registers[c] = registers[a] * registers[b];
        return registers;
    }

    public override string GetDescription(long[] registers, long a, long b, long c)
    {
        return $"Multiply register. Stores into register {c} the result of multiplying register {a} ({registers[a]}) and register {b} ({registers[b]}).";
    }

    public override string GetShortDescription(long[] registers, long a, long b, long c)
    {
        return $"reg[{c}] = {registers[a]} * {registers[b]}.";
    }
}