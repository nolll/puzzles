namespace Core.OperationComputer
{
    public class BoriOperation : Operation
    {
        public override string Name => "bori";

        public override int[] Execute(int[] registers, int a, int b, int c)
        {
            registers[c] = registers[a] | b;
            return registers;
        }
    }
}