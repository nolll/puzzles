namespace Core.OperationComputer
{
    public class SetiOperation : Operation
    {
        public override string Name => "seti";

        public override int[] Execute(int[] registers, int a, int b, int c)
        {
            registers[c] = a;
            return registers;
        }
    }
}