namespace Pzl.Tools.Computers.Operation;

public class GtirOperation() : Operation("gtir", OperationType.Gtir)
{
    public override void Execute(long[] registers, long a, long b, long c) => 
        registers[c] = a > registers[b] ? 1 : 0;
}