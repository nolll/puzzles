namespace Core.Computer.Instructions
{
    public abstract class Parameter
    {
        public long Value { get; }

        protected Parameter(long value)
        {
            Value = value;
        }
    }
}