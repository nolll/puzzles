namespace Pzl.Tools.Computers.Operation;

public class BoriOperation() : Operation("bori", OperationType.Bori)
{
    public override void Execute(long[] registers, long a, long b, long c) => 
        registers[c] = registers[a] | b;
}