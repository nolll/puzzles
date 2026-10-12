namespace Pzl.Tools.Computers.Operation;

public class BorrOperation() : Operation("borr", OperationType.Borr)
{
    public override void Execute(long[] registers, long a, long b, long c) => 
        registers[c] = registers[a] | registers[b];
}