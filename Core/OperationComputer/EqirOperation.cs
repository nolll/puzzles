namespace Core.OperationComputer
{
    public class EqirOperation : Operation
    {
        public override string Name => "eqir";

        public override int[] Execute(int[] registers, int a, int b, int c)
        {
            registers[c] = a == registers[b] ? 1 : 0;
            return registers;
        }
    }
}