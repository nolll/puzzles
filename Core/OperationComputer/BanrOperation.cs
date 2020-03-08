namespace Core.OperationComputer
{
    public class BanrOperation : Operation
    {
        public BanrOperation() : base("banr")
        {
        }

        public override long[] Execute(long[] registers, long a, long b, long c)
        {
            registers[c] = registers[a] & registers[b];
            return registers;
        }
    }
}