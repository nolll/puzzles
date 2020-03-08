namespace Core.OperationComputer
{
    public abstract class Operation
    {
        public abstract string Name { get; }
        public abstract int[] Execute(int[] registers, int a, int b, int c);
    }
}