namespace Pzl.Tools.Computers.Operation;

public class EqriOperation() : Operation("eqri", OperationType.Eqri)
{
    public override void Execute(long[] registers, long a, long b, long c) => 
        registers[c] = registers[a] == b ? 1 : 0;
}