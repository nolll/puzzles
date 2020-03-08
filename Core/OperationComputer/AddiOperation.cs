namespace Core.OperationComputer
{
    public class AddiOperation : Operation
    {
        public AddiOperation() : base("addi")
        {
        }

        public override long[] Execute(long[] registers, long a, long b, long c)
        {
            registers[c] = registers[a] + b;
            return registers;
        }
    }
}