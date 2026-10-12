namespace Pzl.Tools.Computers.Operation;

public class GtriOperation() : Operation("gtri", OperationType.Gtri)
{
    public override void Execute(long[] registers, long a, long b, long c) => 
        registers[c] = registers[a] > b ? 1 : 0;
}