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
    }
}