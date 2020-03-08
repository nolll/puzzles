namespace Core.OperationComputer
{
    public class BaniOperation : Operation
    {
        public override string Name => "bani";

        public override int[] Execute(int[] registers, int a, int b, int c)
        {
            registers[c] = registers[a] & b;
            return registers;
        }
    }
}