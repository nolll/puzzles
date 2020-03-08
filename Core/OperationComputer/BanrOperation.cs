namespace Core.OperationComputer
{
    public class BanrOperation : Operation
    {
        public override string Name => "banr";

        public override int[] Execute(int[] registers, int a, int b, int c)
        {
            registers[c] = registers[a] & registers[b];
            return registers;
        }
    }
}