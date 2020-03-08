namespace Core.OperationComputer
{
    public class MuliOperation : Operation
    {
        public override string Name => "muli";

        public override int[] Execute(int[] registers, int a, int b, int c)
        {
            registers[c] = registers[a] * b;
            return registers;
        }
    }
}