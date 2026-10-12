namespace Pzl.Tools.Computers.Operation;

public class BaniOperation() : Operation("bani", OperationType.Bani)
{
    public override void Execute(long[] registers, long a, long b, long c) => 
        registers[c] = registers[a] & b;
}