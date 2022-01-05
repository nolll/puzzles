namespace Core.Common.Computers.Operation;

public class SetrOperation : Operation
{
    public SetrOperation() : base("setr")
    {
    }

    public override long[] Execute(long[] registers, long a, long b, long c)
    {
        registers[c] = registers[a];
        return registers;
    }

    public override string GetDescription(long[] registers, long a, long b, long c)
    {
        return $"Set register. Copies the contents of register {a} ({registers[a]}) into register {c}.";
    }

    public override string GetShortDescription(long[] registers, long a, long b, long c)
    {
        return $"reg[{c}] = {registers[a]}.";
    }
}