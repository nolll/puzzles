namespace Pzl.Tools.Computers.Operation;

public class MuliOperation() : Operation("muli", OperationType.Muli)
{
    public override void Execute(long[] registers, long a, long b, long c) => 
        registers[c] = registers[a] * b;
}