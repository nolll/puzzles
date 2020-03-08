namespace Core.OperationComputer
{
    public class SetrOperation : Operation
    {
        public override string Name => "setr";

        public override int[] Execute(int[] registers, int a, int b, int c)
        {
            registers[c] = registers[a];
            return registers;
        }
    }
}