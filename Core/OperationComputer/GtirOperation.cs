namespace Core.OperationComputer
{
    public class GtirOperation : Operation
    {
        public override string Name => "gtir";

        public override int[] Execute(int[] registers, int a, int b, int c)
        {
            registers[c] = a > registers[b] ? 1 : 0;
            return registers;
        }
    }
}