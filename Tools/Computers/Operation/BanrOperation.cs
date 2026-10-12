namespace Pzl.Tools.Computers.Operation;

public class BanrOperation() : Operation("banr", OperationType.Banr)
{
    public override void Execute(long[] registers, long a, long b, long c) => 
        registers[c] = registers[a] & registers[b];
}