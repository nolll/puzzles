namespace Core.OperationComputer
{
    public class BaniOperation : Operation
    {
        public BaniOperation() : base("bani")
        {
        }

        public override long[] Execute(long[] registers, long a, long b, long c)
        {
            registers[c] = registers[a] & b;
            return registers;
        }

        public override string GetDescription(long[] registers, long a, long b, long c)
        {
            return $"Bitwise AND immediate. Stores into register {c} the result of the bitwise AND of register {a} ({registers[a]}) and value {b}.";
        }

        public override string GetShortDescription(long[] registers, long a, long b, long c)
        {
            return $"reg[{c}] = {registers[a]} & {b}.";
        }
    }
}