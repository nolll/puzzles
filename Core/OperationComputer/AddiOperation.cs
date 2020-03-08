namespace Core.OperationComputer
{
    public class AddiOperation : Operation
    {
        public override string Name => "addi";

        public override int[] Execute(int[] registers, int a, int b, int c)
        {
            registers[c] = registers[a] + b;
            return registers;
        }
    }
}