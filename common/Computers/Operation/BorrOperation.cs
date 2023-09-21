namespace common.Computers.Operation;

public class BorrOperation : Operation
{
    public BorrOperation() : base("borr")
    {
    }

    public override void Execute(long[] registers, long a, long b, long c)
    {
        registers[c] = registers[a] | registers[b];
    }

    public override string GetDescription(long[] registers, long a, long b, long c)
    {
        return $"Bitwise OR register. Stores into register {c} the result of the bitwise OR of register {a} ({registers[a]}) and register {b} ({registers[b]}).";
    }

    public override string GetShortDescription(long[] registers, long a, long b, long c)
    {
        return $"reg[{c}] = {registers[a]} | {registers[b]}.";
    }
}