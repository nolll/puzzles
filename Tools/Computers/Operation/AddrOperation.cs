namespace Pzl.Tools.Computers.Operation;

public class AddrOperation() : Operation("addr", OperationType.Addr)
{
    public override void Execute(long[] registers, long a, long b, long c) => 
        registers[c] = registers[a] + registers[b];
}