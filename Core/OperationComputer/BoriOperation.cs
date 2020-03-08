namespace Core.OperationComputer
{
    public class BoriOperation : Operation
    {
        public BoriOperation() : base("bori")
        {
        }

        public override long[] Execute(long[] registers, long a, long b, long c)
        {
            registers[c] = registers[a] | b;
            return registers;
        }
    }
}