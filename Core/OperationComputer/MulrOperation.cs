namespace Core.OperationComputer
{
    public class MulrOperation : Operation
    {
        public MulrOperation() : base("mulr")
        {
        }

        public override long[] Execute(long[] registers, long a, long b, long c)
        {
            registers[c] = registers[a] * registers[b];
            return registers;
        }
    }
}