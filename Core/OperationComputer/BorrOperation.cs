namespace Core.OperationComputer
{
    public class BorrOperation : Operation
    {
        public BorrOperation() : base("borr")
        {
        }

        public override long[] Execute(long[] registers, long a, long b, long c)
        {
            registers[c] = registers[a] | registers[b];
            return registers;
        }
    }
}