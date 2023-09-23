namespace Common.Computers.Operation;

public class EqrrOperation : Operation
{
    public EqrrOperation() : base("eqrr")
    {
    }

    public override void Execute(long[] registers, long a, long b, long c)
    {
        registers[c] = registers[a] == registers[b] ? 1 : 0;
    }

    public override string GetDescription(long[] registers, long a, long b, long c)
    {
        return $"Equal register/register. Sets register {c} to 1 if register {a} ({registers[a]}) is equal to register {b} ({registers[b]}). Otherwise, register {c} is set to 0.";
    }

    public override string GetShortDescription(long[] registers, long a, long b, long c)
    {
        return $"reg[{c}] = {registers[a]} == {registers[b]} ? 1 : 0.";
    }
}