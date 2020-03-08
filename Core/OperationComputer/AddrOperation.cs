namespace Core.OperationComputer
{
    public class AddrOperation : Operation
    {
        public AddrOperation() : base("addr")
        {
        }

        public override long[] Execute(long[] registers, long a, long b, long c)
        {
            registers[c] = registers[a] + registers[b];
            return registers;
        }
    }
}