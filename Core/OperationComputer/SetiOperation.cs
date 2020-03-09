namespace Core.OperationComputer
{
    public class SetiOperation : Operation
    {
        public SetiOperation() : base("seti")
        {
        }

        public override long[] Execute(long[] registers, long a, long b, long c)
        {
            registers[c] = a;
            return registers;
        }

        public override string GetDescription(long[] registers, long a, long b, long c)
        {
            return $"Set immediate. Stores value {a} into register {c}.";
        }

        public override string GetShortDescription(long[] registers, long a, long b, long c)
        {
            return $"reg[{c}] = {a}.";
        }
    }
}