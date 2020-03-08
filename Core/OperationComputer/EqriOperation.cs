namespace Core.OperationComputer
{
    public class EqriOperation : Operation
    {
        public EqriOperation() : base("eqri")
        {
        }

        public override long[] Execute(long[] registers, long a, long b, long c)
        {
            registers[c] = registers[a] == b ? 1 : 0;
            return registers;
        }
    }
}