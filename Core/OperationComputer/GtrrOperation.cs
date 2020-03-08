namespace Core.OperationComputer
{
    public class GtrrOperation : Operation
    {
        public GtrrOperation() : base("gtrr")
        {
        }

        public override long[] Execute(long[] registers, long a, long b, long c)
        {
            registers[c] = registers[a] > registers[b] ? 1 : 0;
            return registers;
        }
    }
}