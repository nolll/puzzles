namespace Pzl.Tools.Computers.Operation;

public class AddiOperation() : Operation("addi", OperationType.Addi)
{
    public override void Execute(long[] registers, long a, long b, long c) => 
        registers[c] = registers[a] + b;

    public override string GetDescription(long[] registers, long a, long b, long c) => 
        $"Add immediate. Stores into register {c} the result of adding register {a} ({registers[a]}) and value {b}.";

    public override string GetShortDescription(long[] registers, long a, long b, long c) => 
        $"reg[{c}] = {registers[a]} + {b}.";
}