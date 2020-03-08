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
    }
}