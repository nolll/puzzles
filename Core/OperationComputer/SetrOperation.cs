namespace Core.OperationComputer
{
    public class SetrOperation : Operation
    {
        public SetrOperation() : base("setr")
        {
        }

        public override long[] Execute(long[] registers, long a, long b, long c)
        {
            registers[c] = registers[a];
            return registers;
        }
    }
}