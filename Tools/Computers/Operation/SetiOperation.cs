namespace Pzl.Tools.Computers.Operation;

public class SetiOperation() : Operation("seti", OperationType.Seti)
{
    public override void Execute(long[] registers, long a, long b, long c) => 
        registers[c] = a;

    public override string GetDescription(long[] registers, long a, long b, long c) => 
        $"Set immediate. Stores value {a} into register {c}.";

    public override string GetShortDescription(long[] registers, long a, long b, long c) => 
        $"reg[{c}] = {a}.";
}