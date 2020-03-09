namespace Core.OperationComputer
{
    public class BanrOperation : Operation
    {
        public BanrOperation() : base("banr")
        {
        }

        public override long[] Execute(long[] registers, long a, long b, long c)
        {
            registers[c] = registers[a] & registers[b];
            return registers;
        }

        public override string GetDescription(long[] registers, long a, long b, long c)
        {
            return $"Bitwise AND register. Stores into register {c} the result of the bitwise AND of register {a} ({registers[a]}) and register {b} ({registers[b]}).";
        }

        public override string GetShortDescription(long[] registers, long a, long b, long c)
        {
            return $"reg[{c}] = {registers[a]} & {registers[b]}.";
        }
    }
}