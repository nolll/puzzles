namespace Pzl.Tools.Computers.Operation;

public class SetrOperation() : Operation("setr", OperationType.Setr)
{
    public override void Execute(long[] registers, long a, long b, long c) =>registers[c] = registers[a];

    public override string GetDescription(long[] registers, long a, long b, long c) => 
        $"Set register. Copies the contents of register {a} ({registers[a]}) into register {c}.";

    public override string GetShortDescription(long[] registers, long a, long b, long c) => 
        $"reg[{c}] = {registers[a]}.";
}