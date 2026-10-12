namespace Pzl.Tools.Computers.Operation;

public class SetrOperation() : Operation("setr", OperationType.Setr)
{
    public override void Execute(long[] registers, long a, long b, long c) =>registers[c] = registers[a];
}