namespace Pzl.Tools.Computers.Operation;

public class EqriOperation() : Operation("eqri", OperationType.Eqri)
{
    public override void Execute(long[] registers, long a, long b, long c) => 
        registers[c] = registers[a] == b ? 1 : 0;

    public override string GetDescription(long[] registers, long a, long b, long c) => 
        $"Equal register/immediate. Sets register {c} to 1 if register {a} ({registers[a]}) is equal to value {b}. Otherwise, register {c} is set to 0.";

    public override string GetShortDescription(long[] registers, long a, long b, long c) => 
        $"reg[{c}] = {registers[a]} == {b} ? 1 : 0.";
}