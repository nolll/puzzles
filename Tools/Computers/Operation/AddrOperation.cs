namespace Pzl.Tools.Computers.Operation;

public class AddrOperation() : Operation("addr", OperationType.Addr)
{
    public override void Execute(long[] registers, long a, long b, long c) => 
        registers[c] = registers[a] + registers[b];

    public override string GetDescription(long[] registers, long a, long b, long c) => 
        $"Add register. Stores into register {c} the result of adding register {a} ({registers[a]}) and register {b} ({registers[b]}).";

    public override string GetShortDescription(long[] registers, long a, long b, long c) => 
        $"reg[{c}] = {registers[a]} + {registers[b]}.";
}