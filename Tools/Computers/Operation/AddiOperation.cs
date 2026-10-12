namespace Pzl.Tools.Computers.Operation;

public class AddiOperation() : Operation("addi", OperationType.Addi)
{
    public override void Execute(long[] registers, long a, long b, long c) => 
        registers[c] = registers[a] + b;
}