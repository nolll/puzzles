namespace Puzzles.common.Computers.Operation;

public class SetrOperation : Operation
{
    public SetrOperation() : base("setr")
    {
    }

    public override void Execute(long[] registers, long a, long b, long c)
    {
        registers[c] = registers[a];
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