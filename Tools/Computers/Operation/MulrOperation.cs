namespace Pzl.Tools.Computers.Operation;

public class MulrOperation() : Operation("mulr", OperationType.Mulr)
{
    public override void Execute(long[] registers, long a, long b, long c) =>
        registers[c] = registers[a] * registers[b];
}