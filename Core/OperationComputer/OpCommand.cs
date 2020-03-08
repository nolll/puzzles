namespace Core.OperationComputer
{
    public class OpCommand
    {
        public string Operation { get; }
        public int A { get; }
        public int B { get; }
        public int C { get; }

        public OpCommand(string operation, int a, int b, int c)
        {
            Operation = operation;
            A = a;
            B = b;
            C = c;
        }
    }
}