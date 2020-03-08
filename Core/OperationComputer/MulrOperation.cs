namespace Core.OperationComputer
{
    public class MulrOperation : Operation
    {
        public override string Name => "mulr";

        public override int[] Execute(int[] registers, int a, int b, int c)
        {
            registers[c] = registers[a] * registers[b];
            return registers;
        }
    }
}