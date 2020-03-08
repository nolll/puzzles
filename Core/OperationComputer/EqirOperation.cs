namespace Core.OperationComputer
{
    public class EqirOperation : Operation
    {
        public EqirOperation() : base("eqir")
        {
        }

        public override long[] Execute(long[] registers, long a, long b, long c)
        {
            registers[c] = a == registers[b] ? 1 : 0;
            return registers;
        }
    }
}