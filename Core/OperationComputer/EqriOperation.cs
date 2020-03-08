namespace Core.OperationComputer
{
    public class EqriOperation : Operation
    {
        public override string Name => "eqri";

        public override int[] Execute(int[] registers, int a, int b, int c)
        {
            registers[c] = registers[a] == b ? 1 : 0;
            return registers;
        }
    }
}