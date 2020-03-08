namespace Core.OperationComputer
{
    public class AddrOperation : Operation
    {
        public override string Name => "addr";

        public override int[] Execute(int[] registers, int a, int b, int c)
        {
            registers[c] = registers[a] + registers[b];
            return registers;
        }
    }
}