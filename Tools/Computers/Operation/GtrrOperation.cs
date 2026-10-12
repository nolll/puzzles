namespace Pzl.Tools.Computers.Operation;

public class GtrrOperation() : Operation("gtrr", OperationType.Gtrr)
{
    public override void Execute(long[] registers, long a, long b, long c) => 
        registers[c] = registers[a] > registers[b] ? 1 : 0;
}