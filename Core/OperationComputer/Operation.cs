namespace Core.OperationComputer
{
    public abstract class Operation
    {
        public string Name { get; }
        public string Description { get; }
        public abstract long[] Execute(long[] registers, long a, long b, long c);

        protected Operation(string name)
        {
            Name = name;
            //Description = description;
        }
    }
}