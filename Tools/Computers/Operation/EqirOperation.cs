namespace Pzl.Tools.Computers.Operation;

public class EqirOperation() : Operation("eqir", OperationType.Eqir)
{
    public override void Execute(long[] registers, long a, long b, long c) => 
        registers[c] = a == registers[b] ? 1 : 0;
}