namespace Core.OperationComputer
{
    public class BorrOperation : Operation
    {
        public override string Name => "borr";

        public override int[] Execute(int[] registers, int a, int b, int c)
        {
            registers[c] = registers[a] | registers[b];
            return registers;
        }
    }
}