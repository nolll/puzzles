namespace common.Computers.Operation;

public class SetiOperation : Operation
{
    public SetiOperation() : base("seti")
    {
    }

    public override void Execute(long[] registers, long a, long b, long c)
    {
        registers[c] = a;
    }

    public override string GetDescription(long[] registers, long a, long b, long c)
    {
        return $"Set immediate. Stores value {a} into register {c}.";
    }

    public override string GetShortDescription(long[] registers, long a, long b, long c)
    {
        return $"reg[{c}] = {a}.";
    }
}