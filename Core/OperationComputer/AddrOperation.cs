namespace Core.OperationComputer
{
    public class AddrOperation : Operation
    {
        public AddrOperation() : base("addr")
        {
        }

        public override long[] Execute(long[] registers, long a, long b, long c)
        {
            registers[c] = registers[a] + registers[b];
            return registers;
        }

        public override string GetDescription(long[] registers, long a, long b, long c)
        {
            return $"Add register. Stores into register {c} the result of adding register {a} ({registers[a]}) and register {b} ({registers[b]}).";
        }

        public override string GetShortDescription(long[] registers, long a, long b, long c)
        {
            return $"reg[{c}] = {registers[a]} + {registers[b]}.";
        }
    }
}