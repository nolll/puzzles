namespace Core.OperationComputer
{
    public class MuliOperation : Operation
    {
        public MuliOperation() : base("muli")
        {
        }

        public override long[] Execute(long[] registers, long a, long b, long c)
        {
            registers[c] = registers[a] * b;
            return registers;
        }
    }
}